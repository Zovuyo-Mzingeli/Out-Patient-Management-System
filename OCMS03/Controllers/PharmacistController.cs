using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories.PatientMedRepositories;
using OCMS03.Models.Repositories.PrescriptionRepositories;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.DoctorViewModel;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    [Authorize(Roles = "Pharmacist")]
    public class PharmacistController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPrescriptionRepository prescriptionRepos;
        private readonly Cart cart;
        private readonly IPatientMedRepository repository;
        private readonly IWebHostEnvironment hostEnvironment;

        public PharmacistController(OCMS03_TheCollectiveContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IPrescriptionRepository prescriptionRepos, Cart cart, IPatientMedRepository repository, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.prescriptionRepos = prescriptionRepos;
            this.cart = cart;
            this.repository = repository;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult IssueMedication(string id)
        {
            try
            {
                Patient_Medication meda = repository.GetPatientMeds(id);
                meda.MedsReceived = true;

                repository.IssueMedication(meda);
                Notify("Patient has collected their medication");
            }
            catch (Exception)
            {
                Notify("There was an issue removing patient medication from list", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(List));
        }
        public ViewResult List()
        {
            try
            {
                var patMeds = repository.Patient_Medications.Where(o => !o.MedsReceived);
                var patMedList = patMeds.Select(a => new Patient_Medication
                {
                    PatientId = a == null ? "<Not Assigned>" : (a.Patient.FullName ?? "<Not Assigned>"),
                    PharmacistId = a == null ? "<Not Assigned>" : (a.Pharmacist.FullName ?? "<Not Assigned>"),
                    Date = a.Date
                })
                .ToList();
                return View(patMeds);
            }
            catch (Exception)
            {
                Notify("There was an issue viewing patient medication from list", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpPost]
        public IActionResult IssueMeds(string id)
        {
            Patient_Medication patient_ = repository.Patient_Medications
            .FirstOrDefault(o => o.Patient_MedsId == id);
            if (patient_ != null)
            {
                patient_.MedsReceived = true;
                repository.SaveMeds(patient_);
            }
            return RedirectToAction(nameof(List));
        }
        public async Task<IActionResult> Checkout(PatMedViewModel model)
        {
            var patientListItems = await GetPatientsListItemsAsync();
            model.Patients = patientListItems;
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Checkout(PatMedViewModel model, string id)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var patientListItems = await GetPatientsListItemsAsync();
                model.Patients = patientListItems;
                if (cart.Lines.Count() == 0)
                {
                    Notify("Sorry there's no medication saved for this patient", notificationType: NotificationType.error);
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    var patMeds = new Patient_Medication
                    {
                        PharmacistId = currentUser.Id,
                        PatientId = model.PatientId,
                        Date = DateTime.Today,
                        Lines = cart.Lines.ToArray()
                    };
                    repository.SaveMeds(patMeds);
                    return RedirectToAction(nameof(CartController.Index), "Cart");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {
                Notify("Sorry something went wrong, please try again later", notificationType: NotificationType.error);
            }
            return View(model);
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
        public IActionResult PrescriptionDetails(string id)
        {
            var model = context.tblPrescription.Find(id);
            return View(model);
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var pres = await context.tblPrescription.CountAsync();
            ViewBag.prescCount = pres;

            var patient = await userManager.GetUsersInRoleAsync("Patient");
            var patientsListItems = patient.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.PatCounter = patientsListItems;

            var prescr = context.tblPrescription.AsNoTracking()
                //.Where(d => d.Date == DateTime.Today)
                .Include(c => c.DoctorOrNurse)
                .Include(p => p.Patient)
                .OrderByDescending(a => a.Date);
                //.ToListAsync();
            var model = await PagingList.CreateAsync(prescr, 3, page);
            return View(model);
        }
        private async Task<IEnumerable<SelectListItem>> GetPatientsListItemsAsync()
        {
            List<ViewModelUserRole> petients = new List<ViewModelUserRole>();
            var patient = await userManager.GetUsersInRoleAsync("Patient");
            var patientListItems = patient.Select(pts => new SelectListItem
            {
                Text = pts.PersonelDetails,
                Value = pts.Id
            })
            .ToList();

            return patientListItems;
        }
        private async Task<IEnumerable<SelectListItem>> GetDoctorsListItemsAsync()
        {
            List<ViewModelUserRole> doctors = new List<ViewModelUserRole>();
            var drs = await userManager.GetUsersInRoleAsync("Doctor");
            var doctorsListItems = drs.Select(dr => new SelectListItem
            {
                Text = $"Dr. {dr.LastName}",
                Value = dr.Id
            })
            .ToList();

            return doctorsListItems;
        }
        private void PopulateMedicationDropDownList(object selectedMeds = null)
        {
            var meds = from d in context.tblMedication
                      orderby d.ProductName
                      select d;
            ViewBag.MedicationId = new SelectList(meds.AsNoTracking(), "MedicationId", "MedDetails",
            selectedMeds);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            PopulateCityDropDownList();
            PopulateProvinceDropDownList();
            var model = new EditUserViewModel
            {
                Race = user.Race,
                Dob = user.Dob,
                Email = user.Email,
                Title = user.Title,
                Gender = user.Gender,
                CityId = user.CityId,
                Idnumber = user.Idnumber,
                LastName = user.LastName,
                Username = user.UserName,
                ClinicId = user.ClinicId,
                FirstName = user.FirstName,
                HospitalId = user.HospitalId,
                Occupation = user.Occupation,
                NextOfName = user.NextOfName,
                PostalCode = user.PostalCode,
                ProvinceId = user.ProvinceId,
                PhoneNumber = user.PhoneNumber,
                Nationality = user.Nationality,
                Citizenship = user.Citizenship,
                Relationship = user.Relationship,
                DepartmentId = user.DepartmentId,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                Specialization = user.Specialization,
                NextOfKinNumber = user.NextOfKinNumber,
                NextOfKinSurname = user.NextOfKinSurname,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {

            string uniqueFileName = UploadedFile(model);
            PopulateCityDropDownList();
            PopulateProvinceDropDownList();
            if (!ModelState.IsValid)
            {
                Notify("All field are required", notificationType: NotificationType.warning);
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            user.Dob = model.Dob;
            user.Race = model.Race;
            user.Title = model.Title;
            user.Gender = model.Gender;
            user.CityId = model.CityId;
            user.Idnumber = model.Idnumber;
            user.ClinicId = model.ClinicId;
            user.LastName = model.LastName;
            user.ImagePath = uniqueFileName;
            user.FirstName = model.FirstName;
            user.ProvinceId = model.ProvinceId;
            user.PostalCode = model.PostalCode;
            user.NextOfName = model.NextOfName;
            user.Occupation = model.Occupation;
            user.HospitalId = model.HospitalId;
            user.Nationality = model.Nationality;
            user.Citizenship = model.Citizenship;
            user.AddressLine1 = model.AddressLine1;
            user.AddressLine2 = model.AddressLine2;
            user.Relationship = model.Relationship;
            user.DepartmentId = model.DepartmentId;
            user.Specialization = model.Specialization;
            user.NextOfKinNumber = model.NextOfKinNumber;
            user.NextOfKinSurname = model.NextOfKinSurname;

            PopulateCityDropDownList(model.CityId);
            PopulateProvinceDropDownList(model.ProvinceId);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(UserDetails));
        }

        [HttpGet]
        public IActionResult UserDetails()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction(nameof(AccountController.Index), "Account");
            }
            else
            {
                ApplicationUser user = userManager.FindByIdAsync(userId).Result;
                return View(user);
            }

        }
        private string UploadedFile(EditUserViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "profileImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var provinceQuery = from d in context.tblProvince
                                orderby d.ProvinceName
                                select d;
            ViewBag.ProvinceId = new SelectList(provinceQuery.AsNoTracking(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from d in context.tblCity
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
    }
}
