using OCMS03.Models.CommonMapping;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels.DoctorViewModel
{
    public class DoctorViewModel : IMapFrom<ApplicationUser>
    {
        public string tId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Info { get; set; }
        public List<Appointment> PatientAppointments { get; set; } = new List<Appointment>();
    }
}
