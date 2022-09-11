using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    [Authorize(Roles = "Doctor, Nurse")]
    public class ExaminationsController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ExaminationsController(OCMS03_TheCollectiveContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index(MedicalTabViewModel model)
        {
            //if(model == null)
            //{
            //    model = new MedicalTabViewModel
            //    {
            //        ActiveTab = Tab.VSigns
            //    };
            //}
            return View();
        }
        public IActionResult SwitchTabs(string tabName)
        {
            var model = new MedicalTabViewModel();
            switch (tabName)
            {
                case "VSigns":
                    model.ActiveTab = Tab.VSigns;
                    break;

                case "Examination":
                    model.ActiveTab = Tab.Examination;
                    break;

                case "Prescription":
                    model.ActiveTab = Tab.Prescription;
                    break;


                case "Allergies":
                    model.ActiveTab = Tab.Allergies;
                    break;

                case "Referral":
                    model.ActiveTab = Tab.Referral;
                    break;
            }
            return  RedirectToAction(nameof(ExaminationsController.Index), model);
        }
        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> VSigns(MedicalViewModel model)
        {
            var patientsListItems = await GetPatientsListItemsAsync();
            model.Patients = patientsListItems;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VSigns(long? id, MedicalViewModel model)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var patientsListItems = await GetPatientsListItemsAsync();
                model.Patients = patientsListItems;
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    PatientVitals patientVitals = isNew ? new PatientVitals
                    {
                        CheckInDate = DateTime.Now
                    } : context.Set<PatientVitals>().SingleOrDefault(s => s.VitalsId != null);

                    patientVitals.BMI = model.BMI;
                    patientVitals.SPO2 = model.SPO2;
                    patientVitals.Pulse = model.Pulse;
                    patientVitals.Weight = model.Weight;
                    patientVitals.Height = model.Height;
                    patientVitals.StaffId = currentUser.Id;
                    patientVitals.PainScore = model.PainScore;
                    patientVitals.PatientId = model.PatientName;
                    patientVitals.Temperature = model.Temperature;
                    patientVitals.RepertoryRate = model.RepertoryRate;
                    patientVitals.BloodPressure = model.BloodPressure;

                    if (isNew)
                    {
                        context.Add(patientVitals);
                        await context.SaveChangesAsync();
                        Notify("Patient vitals signs was saved successfully");
                        return RedirectToAction(nameof(ExaminationsController.Examination), "Examinations");
                    }
                    else
                    {
                        try
                        {
                            context.Update(patientVitals);
                            await context.SaveChangesAsync();
                            Notify("Patient vitals signs was updated successfully");
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!PatientVitalsExists(patientVitals.VitalsId))
                            { return NotFound(); }
                            else
                            { throw; }
                        }
                    }
                    return View(patientVitals);
                }
            }
            catch (Exception)
            {
                Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Examination(ExaminationViewModel model)
        {
            var patientsListItems = await GetPatientsListItemsAsync();
            model.Patients = patientsListItems;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Examination(long? id, ExaminationViewModel model)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var patientsListItems = await GetPatientsListItemsAsync();
                model.Patients = patientsListItems;
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Diagnosis diagnosis = isNew ? new Diagnosis
                    {
                        CheckInDate = DateTime.Now
                    } : context.Set<Diagnosis>().SingleOrDefault(d => d.DiagnosisCode != null);

                    diagnosis.PatientId = model.PatientName;
                    diagnosis.StaffId = currentUser.Id;
                    diagnosis.ExaminationNotes = model.ExaminationNotes;

                    if (isNew)
                    {
                        context.Add(diagnosis);
                        await context.SaveChangesAsync();
                        Notify("Patient physaical examination was saved successfully");
                        return RedirectToAction(nameof(ExaminationsController.Allergies), "Examinations");
                    }
                    else
                    {
                        try
                        {
                            context.Update(diagnosis);
                            await context.SaveChangesAsync();
                            Notify("Patient physaical examination was updated successfully");
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!DiagnosisExists(diagnosis.DiagnosisCode))
                            { return NotFound(); }
                            else
                            { throw; }
                        }
                    }
                    return View(diagnosis);
                }
            }
            catch (Exception)
            {
                Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Prescription(PrescriptionViewModel model)
        {
            var patientsListItems = await GetPatientsListItemsAsync();
            model.Patients = patientsListItems;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Prescription(long? id, PrescriptionViewModel model)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var patientsListItems = await GetPatientsListItemsAsync();
                model.Patients = patientsListItems;
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Prescription prescription = isNew ? new Prescription
                    {
                        Date = DateTime.Now
                    } : context.Set<Prescription>().SingleOrDefault(d => d.PrescriptionId != null);

                    prescription.PatientId = model.PatientName;
                    prescription.StaffId = currentUser.Id;
                    prescription.PrescriptionNotes = model.PrescriptionNotes;

                    if (isNew)
                    {
                        context.Add(prescription);
                        await context.SaveChangesAsync();
                        Notify("Patient prescription was saved successfully");
                        return RedirectToAction(nameof(ExaminationsController.Referral), "Examinations");
                    }
                    else
                    {
                        try
                        {
                            context.Update(prescription);
                            await context.SaveChangesAsync();
                            Notify("Patient prescription was updated successfully");
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!PrescriptionExists(prescription.PrescriptionId))
                            { return NotFound(); }
                            else
                            { throw; }
                        }
                    }
                    return View(prescription);
                }
            }
            catch (Exception)
            {
                Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Referral(ReferralViewModel model)
        {
            var patientsListItems = await GetPatientsListItemsAsync();
            model.Patients = patientsListItems;
            PopulateDepartmentDropDownList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Referral(long? id, ReferralViewModel model)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var patientsListItems = await GetPatientsListItemsAsync();
                model.Patients = patientsListItems;
                PopulateDepartmentDropDownList();
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Referral referral = isNew ? new Referral
                    {
                        CheckInDate = DateTime.Now
                    } : context.Set<Referral>().SingleOrDefault(d => d.ReferralId != null);

                    referral.PatientId = model.PatientName;
                    referral.StaffId = currentUser.Id;
                    referral.ReferalDescriptin = model.ReferalDescriptin;
                    referral.StaffId = currentUser.Id;
                    referral.DepartmentId = model.DepartmentName;

                    if (isNew)
                    {
                        PopulateDepartmentDropDownList(referral.ReferralId);
                        context.Add(referral);
                        await context.SaveChangesAsync();
                        Notify("Patient was referred successfully");
                        return RedirectToAction(nameof(DoctorController.Schedule), "Doctor");
                    }
                    else
                    {
                        try
                        {
                            context.Update(referral);
                            PopulateDepartmentDropDownList(referral.ReferralId);
                            await context.SaveChangesAsync();
                            Notify("Patient referral was updated successfully");
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ReferralExists(referral.ReferralId))
                            { return NotFound(); }
                            else
                            { throw; }
                        }
                    }
                    return View(referral);
                }
            }
            catch (Exception)
            {
                Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
            }
            return View(model);
        }
        public async Task<IActionResult> Allergies(Patient_AllergyDiagnosisVM model)
        {
            var patientsListItems = await GetPatientsListItemsAsync();
            model.Patients = patientsListItems;
            PopulateAllergiesDropDownList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Allergies(long? id, Patient_AllergyDiagnosisVM model)
        {
            try
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var patientsListItems = await GetPatientsListItemsAsync();
                model.Patients = patientsListItems;
                PopulateAllergiesDropDownList();
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Patient_AllergyDiagnosis patient_Allergy = isNew ? new Patient_AllergyDiagnosis
                    {
                        CheckedDate = DateTime.Now
                    } : context.Set<Patient_AllergyDiagnosis>().SingleOrDefault(d => d.PatientAllergyDiagnosisId != null);

                    patient_Allergy.StaffId = currentUser.Id;
                    patient_Allergy.PatientId = model.PatientName;
                    patient_Allergy.AllergyId = model.AllergyName;
                    patient_Allergy.AllergySymptoms = model.AllergySymptoms;
                    patient_Allergy.PhysicalExamNotes = model.PhysicalExamNotes;
                    patient_Allergy.AllergyDiagnoseTestType = model.AllergyDiagnoseTestType;

                    if (isNew)
                    {
                        PopulateAllergiesDropDownList(patient_Allergy.PatientAllergyDiagnosisId);
                        context.Add(patient_Allergy);
                        await context.SaveChangesAsync();
                        Notify("Patient allergy diagnosis was successfully");
                        return RedirectToAction(nameof(ExaminationsController.Prescription), "Examinations");
                    }
                    else
                    {
                        try
                        {
                            context.Update(patient_Allergy);
                            PopulateAllergiesDropDownList(patient_Allergy.PatientAllergyDiagnosisId);
                            await context.SaveChangesAsync();
                            Notify("Patient allergy diagnosis was updated successfully");
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ReferralExists(patient_Allergy.PatientAllergyDiagnosisId))
                            { return NotFound(); }
                            else
                            { throw; }
                        }
                    }
                    return View(patient_Allergy);
                }
            }
            catch (Exception)
            {
                Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
            }
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
      
        private bool PatientVitalsExists(string id)
        {
            return context.tblPatientVitals.Any(e => e.VitalsId == id);
        }
        private bool DiagnosisExists(string id)
        {
            return context.tblDiagnosis.Any(e => e.DiagnosisCode == id);
        }
        private bool PrescriptionExists(string id)
        {
            return context.tblPrescription.Any(e => e.PrescriptionId == id);
        }
        private bool ReferralExists(string id)
        {
            return context.tblReferral.Any(e => e.ReferralId == id);
        }
        private void GetPatientByName(object selectedPatient = null)
        {
            var patientQuery = from d in context.tblApplicationUser
                               orderby d.LastName
                               select d;
            ViewBag.PatientId = new SelectList(patientQuery.AsNoTracking(), "Id", "LastName",
            selectedPatient);
        }
        private void PopulateDepartmentDropDownList(object selectedDep = null)
        {
            var dep = from d in context.tblDepartment
                               orderby d.DepartmentName
                               select d;
            ViewBag.DepartmentId = new SelectList(dep.AsNoTracking(), "DepartmentId", "DepartmentName",
            selectedDep);
        }
        private void PopulateAllergiesDropDownList(object selectedAllergy = null)
        {
            var allergies = from d in context.tblAllergy
                      orderby d.AllergyTypeName
                      select d;
            ViewBag.AllergyId = new SelectList(allergies.AsNoTracking(), "AllergyId", "AllergyTypeName",
            selectedAllergy);
        }
    }
}