using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCMS03.Models.Content;

namespace OCMS03.Models.Mapping
{
    public class AppointmentMapping
    {
        public AppointmentMapping(EntityTypeBuilder<Appointment> entityBuilder)
        {
            entityBuilder.HasKey(t => t.AppointmentId);
            entityBuilder.Property(t => t.StartTime).IsRequired();
            entityBuilder.Property(t => t.Duration).IsRequired();
            entityBuilder.Property(t => t.isConfirmed).IsRequired();
            entityBuilder.Property(t => t.AppointmentDescription).IsRequired();
            entityBuilder.Property(t => t.HospitalId).IsRequired();
            entityBuilder.Property(t => t.ClinicId).IsRequired();
            entityBuilder.Property(t => t.DoctorId).IsRequired();
            entityBuilder.Property(t => t.NurseId).IsRequired();
            entityBuilder.Property(t => t.PatientId).IsRequired();
        }
    }
}
