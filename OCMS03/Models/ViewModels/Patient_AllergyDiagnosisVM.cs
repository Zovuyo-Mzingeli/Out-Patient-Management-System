using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class Patient_AllergyDiagnosisVM
    {
        public Tab ActiveTab { get; set; }
        public string PatientAllergyDiagnosisId { get; set; }
        public string PhysicalExamNotes { get; set; }
        public string AllergyDiagnoseTestType { get; set; }
        public string AllergySymptoms { get; set; }
        public string PatientName { get; set; }
        public string AllergyName { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
