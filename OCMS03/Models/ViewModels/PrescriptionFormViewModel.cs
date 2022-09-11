using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class PrescriptionFormViewModel
    {
        public string PrescriptionId { get; set; }
        public string PrescriptionNotes { get; set; }
        public string StaffId { get; set; }
        public string PharmacistName { get; set; }
        public string Patient_PrescriptionId { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        [Required]
        public string Dose { get; set; }
        public string Frequency { get; set; }
        [Required]
        public string Duration { get; set; }
        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Evening { get; set; }
        public bool MedsReceived { get; set; }
        public string PatientId { get; set; }
        public string PharmacistId { get; set; }
        public string MedicationId { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
