using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class MedicalTabViewModel
    {
        public Tab ActiveTab { get; set; }
        public PatientVitals patientVitals { get; set; }
        public Diagnosis diagnosis { get; set; }
        public Prescription prescription { get; set; }
        public Referral referral { get; set; }
        public Allergy allergy { get; set; }
    }
    public enum Tab
    {
        VSigns,
        Examination,
        Allergies,
        Prescription,
        Referral
    }
}
