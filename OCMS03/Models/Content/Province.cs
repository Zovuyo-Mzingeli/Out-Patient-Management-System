using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Province
    {
        public Province()
        {
            TblDistrict = new HashSet<District>();
        }
        [Key]
        public string ProvinceId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter province name")]
        [Display(Name = "province name")]
        [MaxLength(50)]
        [MinLength(3)]
        public string ProvinceName { get; set; }

        public virtual ICollection<District> TblDistrict { get; set; }
        public virtual ICollection<ApplicationUser> TblUser { get; set; }
        public virtual ICollection<Clinic> TblClinic { get; set; }
        public virtual ICollection<Hospital> TblHospital { get; set; }

    }
}
