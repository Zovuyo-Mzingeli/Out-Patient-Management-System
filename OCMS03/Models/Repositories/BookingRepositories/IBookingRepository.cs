using OCMS03.Models.Content;
using OCMS03.Models.ViewModels.AppointmentViewMole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.BookingRepositories
{
    public interface IBookingRepository
    {
        Task AddAsync(string AppointmentDescription,
           DateTime AppointmentDate,
           TimeSpan StartTime,
           TimeSpan EndTime,
           string ClinicId,
           string PatientId);

        Task<bool> CheckAvailability(string clinicId, DateTime date, TimeSpan timeStart);
        Task<IEnumerable<AppointmentViewService>> PatientAppointmentsAsync(string patientId);
        Task<IEnumerable<AppointmentViewService>> AllPatientAppointmentsAsync();
        Task<IEnumerable<AppointmentViewService>> AllUnconfirmedAppointmentsAsync();
        Task<IEnumerable<AppointmentViewService>> AllConfirmedAppointmentsAsync();
        //Task<IEnumerable<AppointmentViewService>> ClinicAppointmentsByDateAsync(string clinicId, DateTime date);
        Task<IEnumerable<AppointmentViewService>> StaffAppointmentsByDateAsync(string doctorId, string nurseId, DateTime date);
        Task<IEnumerable<AppointmentViewService>> AppointmentsByDateAsync(DateTime date);
        Task<IEnumerable<AppointmentViewService>> StaffAppointmentsAsync(string doctorId, string nurseId);
        //Task<IEnumerable<AppointmentViewService>> UpdateAppointmentsAsync(string appointmentId, string nurseId, string doctorId);
        Appointment GetAppointment(string appointmentId);
        Appointment ApproveAndAssignStaff(Appointment appointment);
        Appointment CancelAppointment(Appointment appointment);
    }
}
