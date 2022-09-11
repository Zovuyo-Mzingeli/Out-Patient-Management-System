using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class RegisterWalkInsViewModel
    {
        [Key]
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

        public string WalkInId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
       

        public virtual Clinic Clinic { get; set; }
        public virtual Hospital Hospital { get; set; }
        public IEnumerable<SelectListItem> Patients { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
