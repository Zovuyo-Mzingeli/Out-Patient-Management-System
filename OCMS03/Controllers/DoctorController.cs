using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories.BookingRepositories;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.DoctorViewModel;

namespace OCMS03.Controllers
{
    [Authorize(Roles = "Doctor, Nurse")]
    public class DoctorController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        private readonly IBookingRepository bookingRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public SignInManager<ApplicationUser> SignInManager { get; }

        public DoctorController(OCMS03_TheCollectiveContext context, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            this.bookingRepository = bookingRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string id)
        {
            var app = bookingRepository.GetAppointment(id);

            var appts = await context.tblAppointment.CountAsync();
            ViewBag.apptCount = appts;

            var patient = await userManager.GetUsersInRoleAsync("Patient");
            var patientsListItems = patient.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.PatCounter = patientsListItems;

            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var appointments = await bookingRepository.StaffAppointmentsAsync(currentUser.Id, currentUser.Id);
            var model = new DoctorScheduleViewModel
            {
                Appointments = appointments
            };


            var Appts = await context
                    .tblAppointment
                    .Where(a => a.NurseId == currentUser.Id || a.DoctorId == currentUser.Id)
                    .OrderByDescending(a => a.AppointmentDate)
                    .ThenByDescending(a => a.StartTime)
                    .CountAsync();
            ViewBag.CountStaffAppts = Appts;

            var todayPatients = await context
                    .tblAppointment
                    .Where(a => a.NurseId == currentUser.Id || a.DoctorId == currentUser.Id && (a.AppointmentDate == DateTime.Now.Date))
                    .OrderByDescending(a => a.AppointmentDate)
                    .ThenByDescending(a => a.StartTime)
                    .CountAsync();
            ViewBag.CountTodayPatient = todayPatients;

            return View(model);
        }
        [HttpGet]
        public IActionResult ViewAppointmentDetails(string id)
        {
            var app = bookingRepository.GetAppointment(id);

            return View(app);
        }

        public async Task<IActionResult> Schedule(DateTime date)
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);

            var appointments = await bookingRepository.StaffAppointmentsByDateAsync(currentUser.Id, currentUser.Id, date);

            var model = new DoctorScheduleViewModel
            {
                Date = date,
                Appointments = appointments
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Schedule(DoctorScheduleViewModel model)
            => RedirectToAction(nameof(Schedule), model.Date);

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
                Dob = user.Dob,
                Email = user.Email,
                Title = user.Title,
                Gender = user.Gender,
                CityId = user.CityId,
                ClinicId = user.ClinicId,
                Idnumber = user.Idnumber,
                LastName = user.LastName,
                Username = user.UserName,
                FirstName = user.FirstName,
                HospitalId = user.HospitalId,
                Occupation = user.Occupation,
                NextOfName = user.NextOfName,
                PostalCode = user.PostalCode,
                ProvinceId = user.ProvinceId,
                PhoneNumber = user.PhoneNumber,
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
            user.Title = model.Title;
            user.Gender = model.Gender;
            user.CityId = model.CityId;
            user.Idnumber = model.Idnumber;
            user.ClinicId = model.ClinicId;
            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.ProvinceId = model.ProvinceId;
            user.PostalCode = model.PostalCode;
            user.NextOfName = model.NextOfName;
            user.Occupation = model.Occupation;
            user.HospitalId = model.HospitalId;
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
        public IActionResult DoctorsReport()
        {
            return View();
        }
        public IActionResult Done(string id)
        {
            Appointment app = bookingRepository.GetAppointment(id);
            app.IsDone = true;

            bookingRepository.ApproveAndAssignStaff(app);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
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
            var CityQuery = from k in context.tblCity
                            orderby k.CityName
                            select k;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
    }
}
