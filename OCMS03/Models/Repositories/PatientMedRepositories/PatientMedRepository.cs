using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models.Content;
using OCMS03.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.PatientMedRepositories
{
    public class PatientMedRepository : IPatientMedRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public PatientMedRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IQueryable<Patient_Medication> Patient_Medications => context.tblPatient_Medication
            .Include(a => a.Patient)
            .Include(f => f.Pharmacist)
            .Include(p => p.Lines)
            .ThenInclude(m => m.Medication);

        public IQueryable<Medication> Medications => context.tblMedication;

        public async Task<IEnumerable<PatientMedViewModel>> PatientMedicationAsync()
        {
            return await context
                     .tblPatient_Medication
                     .Where(a => a.MedsReceived != true)
                     .OrderByDescending(a => a.Date)
                     .ProjectTo<PatientMedViewModel>()
                     .ToListAsync();
        }

        public void SaveMeds(Patient_Medication _Medication)
        {
            context.AttachRange(_Medication.Lines.Select(l => l.Medication));
            if (_Medication.Patient_MedsId == null)
            {
                context.tblPatient_Medication.Add(_Medication);
            }
            context.SaveChanges();
        }
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

        public Patient_Medication GetPatientMeds(string PatMedsId)
        {
            return context.tblPatient_Medication.FirstOrDefault(p => p.Patient_MedsId == PatMedsId);
        }

        public Patient_Medication IssueMedication(Patient_Medication patMeds)
        {
            var patmedication = context.tblPatient_Medication.Attach(patMeds);
            patmedication.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return patMeds;
        }

    }
}
