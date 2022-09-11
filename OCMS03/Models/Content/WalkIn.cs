using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public class WalkIn
    {
        public string WalkInId { get; set; }
        [PersonalData]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [PersonalData]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }
        [MaxLength(13)]
        [PersonalData]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your ID No.")]
        public string Idnumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your gender type")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your title")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; } = DateTime.Today;
        public string AddressLine1 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your next of kin first name")]
        public string NextOfName { get; set; }
        [PersonalData]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your next of kin last name")]
        public string NextOfKinSurname { get; set; }
        [PersonalData]
        [MaxLength(13)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your next of kin phone number")]
        public string NextOfKinNumber { get; set; }
        [PersonalData]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your relationship with your next of kin")]
        public string Relationship { get; set; }
        public string VistingTime { get; set; }

        [Display(Name = "Personel Details")]
        public string PersonelDetails
        {
            get
            {
                return LastName + " " + FirstName + ", " + Idnumber;
            }
        }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
