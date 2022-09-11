using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class ExaminationViewModel
    {
        public Tab ActiveTab { get; set; }
        public string DiagnosisCode { get; set; }
        public string PatientName { get; set; }
        public DateTime CheckInDate { get; set; }
        public string ExaminationNotes { get; set; }
        public ApplicationUser Patient { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
