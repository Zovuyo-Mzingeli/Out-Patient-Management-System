using OCMS03.Models.Content;
using OCMS03.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.PatientMedRepositories
{
    public interface IPatientMedRepository
    {
        IQueryable<Medication> Medications { get; }
        IQueryable<Patient_Medication> Patient_Medications { get; }
        void SaveMeds(Patient_Medication _Medication);
        Task<IEnumerable<PatientMedViewModel>> PatientMedicationAsync();
        Patient_Medication GetPatientMeds(string PatMedsId);
        Patient_Medication IssueMedication(Patient_Medication patMeds);
    }
}
