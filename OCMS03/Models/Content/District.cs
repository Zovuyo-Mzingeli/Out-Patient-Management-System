using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class District
    {
        [Key]
        public string DistrictId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter district name")]
        [Display(Name ="District")]
        [MinLength(3)]
        public string DistrictName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select province name")]
        public string ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<City> City { get; set; }
       
    }
}
