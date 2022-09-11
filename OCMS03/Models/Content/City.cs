using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class City
    {
        public City()
        {
            TblClinic = new HashSet<Clinic>();
            TblHospital = new HashSet<Hospital>();
        }
        [Key]
        public string CityId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter city name")]
        [MaxLength(50)]
        [MinLength(3)]
        public string CityName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose district name")]
        public string DistrictId { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<Clinic> TblClinic { get; set; }
        public virtual ICollection<Hospital> TblHospital { get; set; }
        
    }
}

