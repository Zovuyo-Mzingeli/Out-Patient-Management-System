using OCMS03.Models.Content;
using OCMS03.Models.ViewModels.AppointmentViewMole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels.DoctorViewModel
{
    public class DoctorScheduleViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;
        public Appointment App { get; set; }
        public string ProfileImage { get; set; }
        public IEnumerable<AppointmentViewService> Appointments { get; set; }
    }
}
