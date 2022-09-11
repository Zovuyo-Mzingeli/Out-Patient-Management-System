using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels.PatientViewModel
{
    public class PatientAppointmentFormViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }
        public string AppointmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your appointment description")]
        public string AppointmentDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose date of your appointment")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose start time of your appointment")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select clinic name")]
        [Display(Name = "Clinic")]
        public string ClinicId { get; set; }
        public string DoctorId { get; set; }
        public string NurseId { get; set; }


        public IEnumerable<SelectListItem> Clinics { get; set; }

        public IEnumerable<SelectListItem> Doctors { get; set; }

        public IEnumerable<SelectListItem> Nurses { get; set; }
    }
}
