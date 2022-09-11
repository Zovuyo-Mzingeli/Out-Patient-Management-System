using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class MedicalViewModel
    {
        public Tab ActiveTab { get; set; }
        public string VitalsId { get; set; }
        public string Temperature { get; set; }
        public string Pulse { get; set; }
        public string RepertoryRate { get; set; }
        public string BloodPressure { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string PainScore { get; set; }
        public string SPO2 { get; set; }
        public DateTime CheckInDate { get; set; }
        public string PatientName { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public string StaffId { get; set; }
        public virtual ApplicationUser Staff { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
