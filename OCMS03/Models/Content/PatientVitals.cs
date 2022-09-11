using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public class PatientVitals
    {
        [Key]
        public string VitalsId { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Temperature { get; set; }
        [Required]
        public string Pulse { get; set; }
        [Required]
        public string RepertoryRate { get; set; }
        [Required]
        public string BloodPressure { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string BMI { get; set; }
        [Required]
        public string PainScore { get; set; }
        [Required]
        public string SPO2 { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Staff { get; set; }
    }
}
