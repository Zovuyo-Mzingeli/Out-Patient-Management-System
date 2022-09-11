using OCMS03.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.PrescriptionRepositories
{
    public interface IPrescriptionRepository
    {
        Task AddAsync(string PatientId,
                string StaffId,
                DateTime Date,
                string Dose,
                string Frequency,
                string Duration,
                bool Morning,
                bool Afternoon,
                bool Evening,
                bool MedsReceived,
                string PharmacistId,
                string PrescriptionId,
                string MedicationId);

        Task<IEnumerable<PrescriptionViewModel>> PrescriptionsForAday();
        Task<IEnumerable<PrescriptionViewModel>> PrescriptionSeenAsync();
    }
}
