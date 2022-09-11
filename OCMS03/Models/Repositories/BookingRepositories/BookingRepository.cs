using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models.Content;
using OCMS03.Models.ViewModels.AppointmentViewMole;

namespace OCMS03.Models.Repositories.BookingRepositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public BookingRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task AddAsync
            (
             string AppointmentDescription,
               DateTime AppointmentDate,
               TimeSpan StartTime,
               TimeSpan EndTime,
               string ClinicId,
               string PatientId
            )
        {
            var appointment = new Appointment
            {
                AppointmentDescription = AppointmentDescription,
                AppointmentDate = AppointmentDate,
                StartTime = StartTime,
                Duration = EndTime.Add(TimeSpan.FromMinutes(15)),
                PatientId = PatientId,
                ClinicId = ClinicId
            };

            await context.tblAppointment.AddAsync(appointment);
            await context.SaveChangesAsync();
        }

        public async Task<bool> CheckAvailability(string doctorId, DateTime date, TimeSpan timeStart)
            => !await context
                    .tblAppointment
                    .AnyAsync(a => a.DoctorId == doctorId
                        && a.AppointmentDate.Date == date.Date
                        && a.StartTime == timeStart);

        public async Task<IEnumerable<AppointmentViewService>> PatientAppointmentsAsync(string patientId)
        {
            return await context
                     .tblAppointment
                     .Where(a => a.PatientId == patientId)
                     .OrderByDescending(a => a.AppointmentDate)
                     .ThenByDescending(a => a.StartTime)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentViewService>> AllPatientAppointmentsAsync()
        {
            return await context
                     .tblAppointment
                     .Where(s => s.apptStatus == 'A')
                     .OrderByDescending(a => a.AppointmentDate)
                     .OrderByDescending(a => a.isConfirmed == false)
                     .ThenByDescending(a => a.StartTime)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentViewService>> AllUnconfirmedAppointmentsAsync()
        {
            return await context
                     .tblAppointment
                     .Where(a => a.isConfirmed == false)
                     .OrderByDescending(a => a.AppointmentDate)
                     .ThenByDescending(a => a.StartTime)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentViewService>> StaffAppointmentsByDateAsync(string doctorId, string nurseId, DateTime date)
             => await context
             .tblAppointment
             .Where(a => a.DoctorId == doctorId || a.NurseId == nurseId && a.AppointmentDate == date && a.IsDone != true)
             .ProjectTo<AppointmentViewService>()
             .ToListAsync();

        public Appointment GetAppointment(string appointmentId)
        {
            return context.tblAppointment.FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        public Appointment ApproveAndAssignStaff(Appointment appointment)
        {
            var appointments = context.tblAppointment.Attach(appointment);
            appointments.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return appointment;
        }
        public Appointment CancelAppointment(Appointment appointment)
        {
            context.tblAppointment.Remove(appointment);
            context.SaveChanges();
            return appointment;
        }
        public async Task<IEnumerable<AppointmentViewService>> AllConfirmedAppointmentsAsync()
        {
            return await context
                     .tblAppointment
                     .Where(a => a.isConfirmed == true)
                     .OrderByDescending(a => a.AppointmentDate)
                     .ThenByDescending(a => a.StartTime)
                     .ProjectTo<AppointmentViewService>()
                     .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentViewService>> StaffAppointmentsAsync(string doctorId, string nurseId)
            => await context
             .tblAppointment
             .Where(a => a.DoctorId == doctorId || a.NurseId == nurseId && (a.IsDone != true))
             .ProjectTo<AppointmentViewService>()
             .ToListAsync();

        public async Task<IEnumerable<AppointmentViewService>> AppointmentsByDateAsync(DateTime date)
        => await context
             .tblAppointment
             .Where(a => a.AppointmentDate == date && a.IsDone != true)
             .ProjectTo<AppointmentViewService>()
             .ToListAsync();

        
    }
}
