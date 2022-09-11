using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class ReferralViewModel
    {
        public Tab ActiveTab { get; set; }
        public string ReferralId { get; set; }
        public string PatientName { get; set; }
        public DateTime CheckInDate { get; set; }
        public string ReferalDescriptin { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
