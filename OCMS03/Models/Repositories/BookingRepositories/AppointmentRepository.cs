using OCMS03.Data;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.BookingRepositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public AppointmentRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public void AddAppointment(Appointment appointment)
        {
            context.tblAppointment.Add(appointment);
            context.SaveChanges();
        }

        public void ConfirmAppointment(string id)
        {
            getAppointmentById(id).isConfirmed = true;
            context.SaveChanges();
        }

        public IEnumerable<Appointment> getAllAppointments()
        {
            return context.tblAppointment;
        }

        public Appointment getAppointmentById(string id)
        {
            return context.tblAppointment.FirstOrDefault(s => s.AppointmentId == id);
        }
    }
}
