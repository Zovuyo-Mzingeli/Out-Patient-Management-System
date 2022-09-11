using Microsoft.AspNetCore.Mvc.Rendering;
using OCMS03.Models.CommonMapping;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class PrescriptionViewModel : IMapFrom<Prescription>
    {
        public Tab ActiveTab { get; set; }
        public string PrescriptionId { get; set; }
        public string PrescriptionNotes { get; set; }
        public string PatientName { get; set; }
        public string StaffId { get; set; }
        public string PharmacistName { get; set; }
        public string SeenByPharmacist { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }


        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Pharmacist { get; set; }
        public virtual ApplicationUser DoctorOrNurse { get; set; }
    }
}
