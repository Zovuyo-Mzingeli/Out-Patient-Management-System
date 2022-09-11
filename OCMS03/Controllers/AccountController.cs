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
using OCMS03.Models.Repositories.ProfileImage;
using OCMS03.Models.ViewModels;
using OCMS03.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserValidator<ApplicationUser> userValidator;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IPasswordValidator<ApplicationUser> passwordValidator;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly OCMS03_TheCollectiveContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserValidator<ApplicationUser> userValidator, RoleManager<ApplicationRole> roleManager,
            IPasswordValidator<ApplicationUser> passwordValidator, IPasswordHasher<ApplicationUser> passwordHasher,
            IEmailSender emailSender,ILogger<AccountController> logger, IUnitOfWork unitOfWork, OCMS03_TheCollectiveContext context, IWebHostEnvironment hostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userValidator = userValidator;
            this.roleManager = roleManager;
            this.passwordValidator = passwordValidator;
            this.passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.context = context;
            webHostEnvironment = hostEnvironment;
        }
        [Authorize(Roles = "Patient")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Register(UserRegistrationModel userModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    UserName = userModel.FirstName
                };
               
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
                    
                    ///var callbackUrl = Url.EmailConfirmationLink(user.Id, ctoken, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(user.Email, ctokenlink);

                   // var isSave = await userManager.AddToRoleAsync(user, role: "Patient");

                    //var addClaimResilt = await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));

                    await signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");

                    Notify("Hi " + user.UserName + " your account was created successfully! Please check your emails to confirm your account");

                    return RedirectToAction(nameof(AccountController.Login), "Account");
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
                            _logger.LogInformation("User logged in.");
                            //return RedirectToAction(nameof(AdministrationController.Index), "Administration");
                            return RedirectToLocal();
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
       
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private IActionResult RedirectToLocal()
        {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(AdministrationController.Index), "Administration");
                }
                else if (User.IsInRole("Patient"))
                {
                    return RedirectToAction(nameof(AccountController.Index), "Account");
                }
                else if (User.IsInRole("Nurse") || User.IsInRole("Doctor"))
                {
                    return RedirectToAction(nameof(DoctorController.Index), "Doctor");
                }
                else if (User.IsInRole("Pharmacist"))
                {
                    return RedirectToAction(nameof(PharmacistController.Index), "Pharmacist");
                }
            return RedirectToAction(nameof(AdministrationController.Index), "Administration");


           // return RedirectToAction(nameof(HomeController.Index), "Home");
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
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        private string UploadedFile(EditUserViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "profileImage");
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