using OCMS03.Data;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ExamRepositories
{
    public class VitalsRepository : IVitalsRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public VitalsRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(string PatientId, string StaffId, DateTime CheckInDate, string Temperature, string Pulse, string RepertoryRate, string BloodPressure, string DYS, string Height, string Weight, string BMI, string PainScore, string SPO2)
        {
            var vSigns = new PatientVitals
            {
                PatientId = PatientId,
                StaffId = StaffId,
                CheckInDate = CheckInDate,
                Temperature = Temperature,
                Pulse = Pulse,
                RepertoryRate = RepertoryRate,
                BloodPressure = BloodPressure,
                Height = Height,
                Weight = Weight,
                PainScore = PainScore,
                SPO2 = SPO2
            };
            await context.tblPatientVitals.AddAsync(vSigns);
            await context.SaveChangesAsync();
        }
    }
}
