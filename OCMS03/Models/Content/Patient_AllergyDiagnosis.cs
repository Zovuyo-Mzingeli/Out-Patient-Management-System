using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public class Patient_AllergyDiagnosis
    {
        [Key]
        public string PatientAllergyDiagnosisId { get; set; }
        [Required]
        public DateTime CheckedDate { get; set; }
        [Required]
        public string AllergyId { get; set; }
        public string PhysicalExamNotes { get; set; }
        public string AllergyDiagnoseTestType { get; set; }
        [Required]
        [MinLength(3)]
        public string AllergySymptoms { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string StaffId { get; set; }
        public ApplicationUser Patient { get; set; }
        public ApplicationUser Staff { get; set; }
        public Allergy Allergy { get; set; }
    }
}
