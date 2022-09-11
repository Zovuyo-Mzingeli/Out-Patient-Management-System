using OCMS03.Data;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories.ExamRepositories
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly OCMS03_TheCollectiveContext context;

        public ExaminationRepository(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(string PatientId, string StaffId, DateTime CheckInDate, string ExaminationNotes, string ReferalDescriptin, string DepartmentId, string AllergyTypeId, string AllergyId, string Prescription, string PhysicalExamNotes, string AllergyDiagnoseTestType)
        {
           

            var diagnosis = new Diagnosis()
            {
                PatientId = PatientId,
                CheckInDate = CheckInDate,
                ExaminationNotes = ExaminationNotes,
                StaffId = StaffId
            };
            await context.tblDiagnosis.AddAsync(diagnosis);
            await context.SaveChangesAsync();

            var allergyDiagnosis = new Patient_AllergyDiagnosis()
            {
                //AllergyTypeId = AllergyDiagnoseTestType,
                PatientId = PatientId,
                PhysicalExamNotes = PhysicalExamNotes,
                AllergyDiagnoseTestType = AllergyDiagnoseTestType
            };
            await context.tblPatientAllergyDiagnosis.AddAsync(allergyDiagnosis);
            await context.SaveChangesAsync();

          
        }

    }
}
