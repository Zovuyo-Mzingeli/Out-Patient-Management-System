using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ExamRepositories
{
    public interface IExaminationRepository
    {
        Task AddAsync(string PatientId,
                string StaffId,
                DateTime CheckInDate,
                string ExaminationNotes,
                string ReferalDescriptin,
                string DepartmentId,
                string AllergyTypeId,
                string AllergyId,
                string Prescription,
                string PhysicalExamNotes,
                string AllergyDiagnoseTestType);
    }
}

