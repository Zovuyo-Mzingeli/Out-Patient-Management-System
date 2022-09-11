using Microsoft.AspNetCore.Http;
using OCMS03.Enums;
using OCMS03.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace OCMS03.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert your date of birth")]
        [MyBirthDateValidation(ErrorMessage = "You cannot be from the Future!")]
        public DateTime Dob { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your ID No.")]
        public string Idnumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your title")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your gender type")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your occupation")]
        public string Occupation { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your specialization")]
        public string Specialization { get; set; }
        public string DepartmentId { get; set; }
        public string HospitalId { get; set; }
        public string ClinicId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your province")]
        public string ProvinceId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your city")]
        public string CityId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your pos")]
        public string PostalCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your next of kin first name")]
        public string NextOfName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your next of kin last name")]
        public string NextOfKinSurname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your next of kin phone number")]
        public string NextOfKinNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your relationship with your next of kin")]
        public string Relationship { get; set; }

        public string StatusMessage { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your race")]
        public string Race { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select your citizen")]
        public string Citizenship { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string Nationality { get; set; }
    }
}
