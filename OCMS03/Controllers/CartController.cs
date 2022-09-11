using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories.PatientMedRepositories;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    public class CartController : BaseController
    {
        private readonly Cart cart;
        private readonly OCMS03_TheCollectiveContext context;
        private readonly IPatientMedRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(Cart cart, OCMS03_TheCollectiveContext context, IPatientMedRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.cart = cart;
            this.context = context;
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(string returnUrl, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PopulateMedicationDropDownList();
                    Prescription getPrescription = await context.tblPrescription.FindAsync(id);

                    return View(new PrescriptionFormViewModel
                    {
                        Cart = cart,
                        //PrescriptionId = getPrescription.PrescriptionId,
                        //PrescriptionNotes = getPrescription.PrescriptionNotes,
                        ReturnUrl = returnUrl
                    });
                }
                catch (Exception)
                {
                    Notify(" already existing in the database", notificationType: NotificationType.error);
                    //return RedirectToAction("Index");
                }
            }
            
            return View();
        }
        public RedirectToActionResult AddToCart(string medicationId, string dose, string frequency, string duration, bool morning, bool afternoon, bool evening, string returnUrl)
        {
            Medication medications = context.tblMedication.Find(medicationId);

            if (medicationId != null)
            {
                cart.AddItem(medications, dose, frequency, duration, morning, afternoon, evening);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(string medicationId, string returnUrl)
        {
            Medication medication = repository.Medications
            .FirstOrDefault(p => p.MedicationId == medicationId);

            if (medication != null)
            {
                cart.RemoveLine(medication);
            }
            return RedirectToAction("Index", new { returnUrl });
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
    }
}
