using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ExamRepositories
{
    public interface IVitalsRepository
    {
        Task AddAsync(string PatientId,
                string StaffId,
                DateTime CheckInDate,
                string Temperature,
                string Pulse,
                string RepertoryRate,
                string BloodPressure,
                string DYS,
                string Height,
                string Weight,
                string BMI,
                string PainScore,
                string SPO2);
    }
}
