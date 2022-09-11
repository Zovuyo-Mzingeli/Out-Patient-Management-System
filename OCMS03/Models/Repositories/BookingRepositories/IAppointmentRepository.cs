using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.BookingRepositories
{
    public interface IAppointmentRepository
    {
        Appointment getAppointmentById(string id);
        IEnumerable<Appointment> getAllAppointments();
        void ConfirmAppointment(string id);
        void AddAppointment(Appointment appointment);
    }
}
