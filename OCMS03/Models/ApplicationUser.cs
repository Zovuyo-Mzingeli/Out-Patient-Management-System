using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OCMS03.Enums;
using OCMS03.Extensions;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCMS03.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [MaxLength(13)]
        [PersonalData]
        public string Idnumber { get; set; }
        public string Race { get; set; }
        public string Citizenship { get; set; }
        public string Nationality { get; set; }
        public string ImagePath { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string LastName { get; set; }
        [PersonalData]
        public string Title { get; set; }
        [PersonalData]
        public string Gender { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string Occupation { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string Specialization { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string DepartmentId { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string HospitalId { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string ClinicId { get; set; }
        [PersonalData]
        [MaxLength(250)]
        public string AddressLine1 { get; set; }
        [PersonalData]
        [MaxLength(250)]
        public string AddressLine2 { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string ProvinceId { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string CityId { get; set; }
        [PersonalData]
        [MaxLength(6)]
        public string PostalCode { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string NextOfName { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string NextOfKinSurname { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string Relationship { get; set; }
        [PersonalData]
        [MaxLength(13)]
        public string NextOfKinNumber { get; set; }

        [PersonalData]
        public bool? IsResetPasswordRequired { get; set; }

        public char UserStatus { get; set; } = 'A';

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        [Display(Name = "Personel Details")]
        public string PersonelDetails
        {
            get
            {
                return LastName + " " + FirstName + ", " + Idnumber;
            }
        }
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - Dob.Year;
                if (Dob > now.AddYears(-age)) age--;
                return age;
            }

        }
        [NotMapped]
        public string PatientIdOrDob
        {
            get
            {
                return string.Format("{0} ({1})", Idnumber, Dob);
            }
        }
        public virtual Department Department { get; set; }
        public virtual Province Province { get; set; }
        public virtual City City { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }

        public List<PatientVitals> PatientVitals { get; set; } = new List<PatientVitals>();
        public List<PatientVitals> StaffRecorded { get; set; } = new List<PatientVitals>();

        public List<Appointment> NurseAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> DoctorAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> PatientAppointments { get; set; } = new List<Appointment>();

        public List<Prescription> DoctorOrNursePrescription { get; set; } = new List<Prescription>();
        public List<Prescription> PatientPrescription { get; set; } = new List<Prescription>();
        public List<Prescription> PharmacistPrescription { get; set; } = new List<Prescription>();

        public List<Diagnosis> Staff { get; set; } = new List<Diagnosis>();
        public List<Diagnosis> PatientDiagnosis { get; set; } = new List<Diagnosis>();

        public List<Patient_AllergyDiagnosis> StaffMember { get; set; } = new List<Patient_AllergyDiagnosis>();
        public List<Patient_AllergyDiagnosis> PatientAllergy { get; set; } = new List<Patient_AllergyDiagnosis>();

        public List<Referral> ReferralStaff { get; set; } = new List<Referral>();
        public List<Referral> ReferralPatient { get; set; } = new List<Referral>();

        public List<Patient_Medication> Patient_Meds { get; set; } = new List<Patient_Medication>();
        //public List<Patient_Prescription> Staff_Prescription { get; set; } = new List<Patient_Prescription>();
        public List<Patient_Medication> Pharmacist_Meds { get; set; } = new List<Patient_Medication>();

        public string DisplayName() { return string.Format("{0}, {1}", LastName, FirstName); }

    }
}
