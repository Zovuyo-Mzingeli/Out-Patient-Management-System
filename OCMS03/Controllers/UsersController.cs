using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.AssignSpecialistViewModel;
using OCMS03.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    [Authorize(Roles = "Receptionist, Admin")]
    public class UsersController : Controller
    {
        private RoleManager<ApplicationRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        public UsersController(RoleManager<ApplicationRole> roleMgr, UserManager<ApplicationUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }
        public ViewResult Index()
           => View(userManager.Users);

      
        public async Task<IActionResult> AllDoctors()
        {
            List<ViewModelUserRole> doctors = new List<ViewModelUserRole>();
            var drs = await userManager.GetUsersInRoleAsync("Doctor");
            foreach (var dr in drs)
            {
                doctors.Add(new ViewModelUserRole
                {
                    Title = dr.Title,
                    FirstName = dr.FirstName,
                    LastName = dr.LastName,
                    Email = dr.Email,
                    PhoneNumber = dr.PhoneNumber,
                    AddressLine1 = dr.AddressLine1,
                    AddressLine2 = dr.AddressLine2,
                    ImagePath = dr.ImagePath
                });
            }
            return View(doctors);
        }
        public async Task<IActionResult> AllNurses()
        {
            List<ViewModelUserRole> nurses = new List<ViewModelUserRole>();
            var nurse = await userManager.GetUsersInRoleAsync("Nurse");
            foreach (var nrs in nurse)
            {
                nurses.Add(new ViewModelUserRole
                {
                    Title = nrs.Title,
                    FirstName = nrs.FirstName,
                    LastName = nrs.LastName,
                    Email = nrs.Email,
                    PhoneNumber = nrs.PhoneNumber,
                    AddressLine1 = nrs.AddressLine1,
                    AddressLine2 = nrs.AddressLine2,
                    ImagePath = nrs.ImagePath
                });
            }
            return View(nurses);
        }
        public async Task<IActionResult> AllPharmacists()
        {
            List<ViewModelUserRole> pharmacists = new List<ViewModelUserRole>();
            var pharmacist = await userManager.GetUsersInRoleAsync("Pharmacist");
            foreach (var phr in pharmacist)
            {
                pharmacists.Add(new ViewModelUserRole
                {
                    Title = phr.Title,
                    FirstName = phr.FirstName,
                    LastName = phr.LastName,
                    Email = phr.Email,
                    PhoneNumber = phr.PhoneNumber,
                    AddressLine1 = phr.AddressLine1,
                    AddressLine2 = phr.AddressLine2,
                    ImagePath = phr.ImagePath
                });
            }
            return View(pharmacists);
        }
        public async Task<IActionResult> AllPatients()
        {
            List<ViewModelUserRole> patients = new List<ViewModelUserRole>();
            var patient = await userManager.GetUsersInRoleAsync("Patient");
            foreach (var dr in patient)
            {
                patients.Add(new ViewModelUserRole
                {
                    Title = dr.Title,
                    FirstName = dr.FirstName,
                    LastName = dr.LastName,
                    Email = dr.Email,
                    PhoneNumber = dr.PhoneNumber,
                    AddressLine1 = dr.AddressLine1,
                    AddressLine2 = dr.AddressLine2,
                    ImagePath = dr.ImagePath
                });
            }
            return View(patients);
        }
    }
}
