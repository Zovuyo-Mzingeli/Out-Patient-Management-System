using OCMS03.Models.CommonMapping;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels.DoctorViewModel
{
    public class DoctorAppointmentViewModel : IMapFrom<Appointment>
    {
        public int AppointmentId { get; set; }

        public string Info { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public TimeSpan TimeStart { get; set; }

        public TimeSpan TimeEnd { get; set; }

        public ApplicationUser Patient { get; set; }
    }
}
