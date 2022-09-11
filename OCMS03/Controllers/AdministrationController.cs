using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OCMS03.Data;
using OCMS03.Extensions;
using OCMS03.Models;
using OCMS03.Models.Repositories.BookingRepositories;
using OCMS03.Models.Repositories.ProfileImage;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.DoctorViewModel;
using OCMS03.Models.ViewModels.PatientViewModel;
using OCMS03.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    //[Authorize(Roles = "Receptionist, Admin")]
    public class AdministrationController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IBookingRepository bookingRepository;
        private readonly ILogger _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdministrationController(OCMS03_TheCollectiveContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager,
            IPasswordValidator<ApplicationUser> passwordValidator, IPasswordHasher<ApplicationUser> passwordHasher,
           IBookingRepository bookingRepository, IEmailSender emailSender, ILogger<AccountController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.bookingRepository = bookingRepository;
            _emailSender = emailSender;
            _logger = logger;
            this.unitOfWork = unitOfWork;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var appts  = await context.tblAppointment.CountAsync();
            ViewBag.apptCount = appts;

           var unconfirmedAppts = await context
                     .tblAppointment
                     .Where(a => a.isConfirmed == false)
                     .OrderByDescending(a => a.AppointmentDate)
                     .ThenByDescending(a => a.StartTime)
                     .CountAsync();
            ViewBag.CountPendingAppts = unconfirmedAppts;

            var patient = await userManager.GetUsersInRoleAsync("Patient");
            var patientsListItems = patient.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.PatCounter = patientsListItems;

            var nurse = await userManager.GetUsersInRoleAsync("Nurse");
            var nurseListItems = nurse.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.NurseCounter = nurseListItems;

            List<RoleViewModel> listofUsers = new List<RoleViewModel>();

            var users = userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
            var roles = roleManager.Roles.ToList();

            foreach (var user in users)
            {
                RoleViewModel u = new RoleViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address1 = user.AddressLine1,
                    Address2 = user.AddressLine2,
                    ProfileImage = user.ImagePath
                };
                foreach (var r in user.UserRoles)
                {
                    u.Roles.Add(r.UserId, roles.Where(x => x.Id == r.RoleId).First().Name);
                }
                listofUsers.Add(u);
            }
            return View(listofUsers);
        }
        [HttpGet]
        public IActionResult ManageUser()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            PopulateClinicDropDownList();
            PopulateHospitalDropDownList();
            PopulateDepartmentDropDownList();
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Register(UserRegistrationModel userModel, string returnUrl = null)
        {
            PopulateClinicDropDownList();
            PopulateHospitalDropDownList();
            PopulateDepartmentDropDownList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    UserName = userModel.FirstName,
                    DepartmentId = userModel.DepartmentId,
                    ClinicId = userModel.ClinicId,
                    HospitalId = userModel.HospitalId
                };
                PopulateClinicDropDownList(userModel.ClinicId);
                PopulateHospitalDropDownList(userModel.HospitalId);
                PopulateDepartmentDropDownList(userModel.DepartmentId);
                var result = await userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var ctoken = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                    var ctokenlink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = ctoken
                    }, protocol: HttpContext.Request.Scheme);

                    await _emailSender.SendEmailConfirmationAsync(user.Email, ctokenlink);
                    ViewBag.token = ctokenlink;

                    await signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");

                    Notify("Hi " + user.UserName + " your account was created successfully! Please check your emails to confirm your account");

                    return RedirectToAction(nameof(UsersController.Index), "Users");
                }
                AddErrorsFromResult(result);
            }
            return View(userModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel details, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await userManager.FindByEmailAsync(details.Email);
                    if (user != null)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, details.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            //_logger.LogInformation("User logged in.");
                            return RedirectToLocal(returnUrl);
                        }
                    }
                }
                catch (Exception)
                {
                    Notify("You don't have access, please use you credetials to login", notificationType: NotificationType.warning);
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                Notify("Invalid credetials! Your email or password is incorrect", notificationType: NotificationType.error);
            }
            return View(details);
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
            PopulateDepartmentDropDownList();
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
            PopulateDepartmentDropDownList(model.DepartmentId);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id ={id} cannot be found";
                return View();
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction();
                }
            }
            return View();
        }
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(AdministrationController.ManageUser), "Administration");
                }
                else if (User.IsInRole("Patient"))
                {
                    return RedirectToAction(nameof(AccountController.Index), "Account");
                }
                else if (User.IsInRole("Nurse") || User.IsInRole("Doctor"))
                {
                    return RedirectToAction(nameof(DoctorController.Schedule), "Doctor");
                }
                else if (User.IsInRole("Pharmacist"))
                {
                    return RedirectToAction(nameof(PharmacistController.Index), "Pharmacist");
                }
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            //EmailConfirmModel model = new EmailConfirmModel();

            if (userId == null || token == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            //if (result.Succeeded)
            //{
            //    model.EmailVerified = true;
            //}
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        //[HttpPost("confirm-email")]
        //public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        //{
        //    var user = await userManager.FindByEmailAsync(model.Email);
        //    if (user != null)
        //    {
        //        if (user.EmailConfirmed)
        //        {
        //            model.EmailVerified = true;
        //            return View(model);
        //        }
        //        var ctoken = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
        //        var ctokenlink = Url.Action("ConfirmEmail", "Account", new
        //        {
        //            userId = user.Id,
        //            token = ctoken
        //        }, protocol: HttpContext.Request.Scheme);


        //        model.EmailSent = true;
        //        ModelState.Clear();
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Something went wrong.");
        //    }
        //    return View(model);
        //}
        public ViewResult ChangePassword(string userName)
        {
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel() { Email = userName };

            return View(resetPasswordViewModel);
        }

        
        //[AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByNameAsync(model.Email);
                    var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

                    if (result.Succeeded)
                    {
                        user.IsResetPasswordRequired = false;
                        await userManager.UpdateAsync(user);
                        TempData["LoginMessage"] = "Password changed successfully";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                        return View(model);
                    }
                }
                catch (Exception)
                {
                    return View(model);
                }
            }
            else
                return View(model);
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
        private void PopulateClinicDropDownList(object selectedClinicId = null)
        {
            var ClinicQuery = from d in context.tblClinic
                              orderby d.ClinicName
                              select d;
            ViewBag.ClinicId = new SelectList(ClinicQuery.AsNoTracking(), "ClinicId", "ClinicName",
            selectedClinicId);
        }
        private void PopulateHospitalDropDownList(object selectedHospital = null)
        {
            var hospitalQuery = from d in context.tblHospital
                                orderby d.HospitalName
                                select d;
            ViewBag.HospitalId = new SelectList(hospitalQuery.ToList(), "HospitalId", "HospitalName",
            selectedHospital);
        }
        private void PopulateDepartmentDropDownList(object selectedDep = null)
        {
            var dep = from d in context.tblDepartment
                      orderby d.DepartmentName
                      select d;
            ViewBag.DepartmentId = new SelectList(dep.AsNoTracking(), "DepartmentId", "DepartmentName",
            selectedDep);
        }

        private string UploadedFile(EditUserViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}