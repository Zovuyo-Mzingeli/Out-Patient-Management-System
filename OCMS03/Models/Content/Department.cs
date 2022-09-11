using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Department
    {
        [Key]
        public string DepartmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter department name")]
        [MinLength(3)]
        public string DepartmentName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select hospital name")]
        public string HospitalId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter email address")]
        [MinLength(4)]
        public string EmailAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter contact number")]
        [MinLength(7)]
        public string ContactNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter fax number")]
        [MinLength(7)]
        public string FaxNumber { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<ApplicationUser> TblUser { get; set; }
        public virtual ICollection<Diagnosis> TblDiagnosis { get; set; }

    }
}
