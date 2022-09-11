using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels.ClinicViewModel
{
    public class ClinicViewModel
    {
        [Key]
        public string ClinicId { get; set; }
        [Required]
        public string ClinicName { get; set; }
        [Required]
        [MaxLength(250)]
        public string AddressLine1 { get; set; }
        [MaxLength(250)]
        public string AddressLine2 { get; set; }
        [MaxLength(50)]
        public string CityId { get; set; }
        [MaxLength(50)]
        public string ProvinceId { get; set; }
        [Required]
        [MaxLength(6)]
        public string PostalCode { get; set; }
        [MaxLength(13)]
        public string Telephone { get; set; }
        [MaxLength(13)]
        public string FaxNumber { get; set; }

        public virtual City City { get; set; }
        public virtual Province Province { get; set; }
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        public virtual List<ApplicationUser> Nurses { get; set; } = new List<ApplicationUser>();
    }
}
