using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Hospital
    {
        [Key]
        public string HospitalId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter hospital name")]
        [Display(Name ="Hospital")]
        public string HospitalName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter address line")]
        [MaxLength(250)][Display(Name = "Address Line1")]
        [MinLength(3)]
        public string AddressLine1 { get; set; }
        [MaxLength(250)]
        
        public string AddressLine2 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose city name")]
        [MaxLength(50)][Display(Name = "City")]
        public string CityId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose province name")]
        [MaxLength(50)]
        public string ProvinceId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter postal code")]
        [MaxLength(6)]
        [MinLength(3)]
        public string PostalCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter telephone")]
        [MaxLength(13)]
        [MinLength(7)]
        public string Telephone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter fax number")]
        [MaxLength(13)]
        [MinLength(7)]
        public string FaxNumber { get; set; }

        public virtual City City { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<Appointment> TblAppointment { get; set; }
        public virtual ICollection<ApplicationUser> TblUser { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

    }
}
