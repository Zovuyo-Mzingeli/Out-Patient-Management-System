using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models.Content;
using OCMS03.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.PrescriptionRepositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public PrescriptionRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(string PatientId, string StaffId, DateTime Date, string Dose, string Frequency, string Duration, bool Morning, bool Afternoon, bool Evening, bool MedsReceived, string PharmacistId, string PrescriptionId, string MedicationId)
        {
            //var prescription = new Patient_Prescription()
            //{
            //    PatientId = PatientId,
            //    StaffId = StaffId,
            //    Date = Date,
            //    Dose = Dose,
            //    Frequency = Frequency,
            //    Duration = Duration,
            //    Morning = Morning,
            //    Afternoon = Afternoon,
            //    Evening = Evening,
            //    MedsReceived = MedsReceived,
            //    PharmacistId = PharmacistId,
            //    PrescriptionId = PrescriptionId,
            //    MedicationId = MedicationId
            //};
            //await context.tblPatient_Prescription.AddAsync(prescription);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrescriptionViewModel>> PrescriptionSeenAsync()
        {
            return await context
                      .tblPrescription
                      .Where(a => a.SeenByPharmacist != true)
                      .OrderByDescending(a => a.Date)
                      .ProjectTo<PrescriptionViewModel>()
                      .ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionViewModel>> PrescriptionsForAday()
        {
            return await context
                     .tblPrescription
                     .Where(a => a.Date == DateTime.Today)
                     .OrderByDescending(a => a.Date)
                     .ThenByDescending(a => a.PrescriptionNotes)
                     .ProjectTo<PrescriptionViewModel>()
                     .ToListAsync();
        }
    }
}
