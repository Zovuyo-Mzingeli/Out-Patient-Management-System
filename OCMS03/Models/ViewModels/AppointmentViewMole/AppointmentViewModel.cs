using OCMS03.Models.CommonMapping;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels.AppointmentViewMole
{
    public class AppointmentViewModel
    {
        public string Tittle { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
