using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Diagnosis
    {
       
        [Key]
        public string DiagnosisCode { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string StaffId { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        [MinLength(10)]
        public string ExaminationNotes { get; set; }

        public virtual ApplicationUser Staff { get; set; }
        public virtual ApplicationUser Patient { get; set; }
    }
}
