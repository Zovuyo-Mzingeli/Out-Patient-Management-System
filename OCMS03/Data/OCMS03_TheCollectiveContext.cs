using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Mapping;

namespace OCMS03.Data
{
    public partial class OCMS03_TheCollectiveContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public OCMS03_TheCollectiveContext()
        {
        }

        public OCMS03_TheCollectiveContext(DbContextOptions<OCMS03_TheCollectiveContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DBOCMS03_tCctive;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        public virtual DbSet<Appointment> tblAppointment { get; set; }
        public virtual DbSet<Allergy> tblAllergy { get; set; }
        public virtual DbSet<Patient_AllergyDiagnosis> tblPatientAllergyDiagnosis { get; set; }
        public virtual DbSet<Medication> tblMedication { get; set; }
        public virtual DbSet<Patient_Medication> tblPatient_Medication { get; set; }
        public virtual DbSet<City> tblCity { get; set; }
        public virtual DbSet<Clinic> tblClinic { get; set; }
        public virtual DbSet<Department> tblDepartment { get; set; }
        public virtual DbSet<Diagnosis> tblDiagnosis { get; set; }
        public virtual DbSet<District> tblDistrict { get; set; }
        public virtual DbSet<Hospital> tblHospital { get; set; }
        public virtual DbSet<Prescription> tblPrescription { get; set; }
        public virtual DbSet<Province> tblProvince { get; set; }
        public virtual DbSet<ApplicationUser> tblApplicationUser { get; set; }
        public virtual DbSet<PatientVitals> tblPatientVitals { get; set; }
        public virtual DbSet<Claim> tblClaims { get; set; }
        public virtual DbSet<CartLine> tblCartLine { get; set; }
        public virtual DbSet<Referral> tblReferral { get; set; }
        public virtual DbSet<WalkIn> tblWalkIn { get; set; }

        //appointments
        public virtual DbSet<Jan> Jan { get; set; }
        public virtual DbSet<Feb> Feb { get; set; }
        public virtual DbSet<Mar> Mar { get; set; }
        public virtual DbSet<Apr> Apr { get; set; }
        public virtual DbSet<May> May { get; set; }
        public virtual DbSet<Jun> Jun { get; set; }
        public virtual DbSet<Jul> Jul { get; set; }
        public virtual DbSet<Aug> Aug { get; set; }
        public virtual DbSet<Sep> Sep { get; set; }
        public virtual DbSet<Oct> Oct { get; set; }
        public virtual DbSet<Nov> Nov { get; set; }
        public virtual DbSet<Dec> Dec { get; set; }

        //approved appointments
        public virtual DbSet<JR> JR { get; set; }
        public virtual DbSet<FR> FR { get; set; }
        public virtual DbSet<MR> MR { get; set; }
        public virtual DbSet<AR> AR { get; set; }
        public virtual DbSet<AR> MA { get; set; }
        public virtual DbSet<JU> JU { get; set; }
        public virtual DbSet<JL> JL { get; set; }
        public virtual DbSet<AU> AU { get; set; }
        public virtual DbSet<SE> SE { get; set; }
        public virtual DbSet<OC> OC { get; set; }
        public virtual DbSet<NO> NO { get; set; }
        public virtual DbSet<DE> DE { get; set; }

        //cancelled appointments
        public virtual DbSet<JA> JA { get; set; }
        public virtual DbSet<FE> FE { get; set; }
        public virtual DbSet<MAR> MAR { get; set; }
        public virtual DbSet<AP> AP { get; set; }
        public virtual DbSet<MY> MY { get; set; }
        public virtual DbSet<JN> JN { get; set; }
        public virtual DbSet<JUL> JUL { get; set; }
        public virtual DbSet<AUGU> AUGU { get; set; }
        public virtual DbSet<SEPT> SEPT { get; set; }
        public virtual DbSet<OCT> OCT { get; set; }
        public virtual DbSet<NOV> NOV { get; set; }
        public virtual DbSet<DEC> DEC { get; set; }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;

                    entity.GetType().GetProperty("apptStatus").SetValue(entity, 'D');
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(dr => dr.DoctorAppointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.PatientAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Appointment>()
               .HasOne(a => a.Nurse)
               .WithMany(p => p.NurseAppointments)
               .HasForeignKey(a => a.NurseId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Prescription>()
                .HasOne(a => a.DoctorOrNurse)
                .WithMany(dr => dr.DoctorOrNursePrescription)
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Prescription>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.PatientPrescription)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Patient_AllergyDiagnosis>()
               .HasOne(a => a.Staff)
               .WithMany(p => p.StaffMember)
               .HasForeignKey(a => a.StaffId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Patient_AllergyDiagnosis>()
               .HasOne(a => a.Patient)
               .WithMany(p => p.PatientAllergy)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
              .Entity<Prescription>()
              .HasOne(a => a.Pharmacist)
              .WithMany(p => p.PharmacistPrescription)
              .HasForeignKey(a => a.PharmacistId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Diagnosis>()
               .HasOne(a => a.Patient)
               .WithMany(p => p.PatientDiagnosis)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Patient_Medication>()
               .HasOne(a => a.Patient)
               .WithMany(p => p.Patient_Meds)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
              .Entity<Patient_Medication>()
              .HasOne(a => a.Pharmacist)
              .WithMany(p => p.Pharmacist_Meds)
              .HasForeignKey(a => a.PharmacistId)
              .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder
            //   .Entity<Patient_Prescription>()
            //   .HasOne(a => a.Staff)
            //   .WithMany(p => p.Staff_Prescription)
            //   .HasForeignKey(a => a.StaffId)
            //   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Diagnosis>()
               .HasOne(a => a.Staff)
               .WithMany(p => p.Staff)
               .HasForeignKey(a => a.StaffId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<PatientVitals>()
               .HasOne(a => a.Patient)
               .WithMany(p => p.PatientVitals)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<PatientVitals>()
               .HasOne(a => a.Staff)
               .WithMany(p => p.StaffRecorded)
               .HasForeignKey(a => a.StaffId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Referral>()
               .HasOne(a => a.Patient)
               .WithMany(p => p.ReferralPatient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Referral>()
               .HasOne(a => a.Staff)
               .WithMany(p => p.ReferralStaff)
               .HasForeignKey(a => a.StaffId)
               .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            modelBuilder.Entity<CartLine>(entity =>
            {
                entity.ToTable("tblCartLine");

                entity.HasKey(e => e.Patient_PrescriptionId);

                entity.Property(e => e.Patient_PrescriptionId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("tblAppointment");

                entity.HasKey(e => e.AppointmentId);

                entity.Property(e => e.AppointmentId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("tblMedication");

                entity.HasKey(e => e.MedicationId);

                entity.Property(e => e.MedicationId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });

            modelBuilder.Entity<Patient_AllergyDiagnosis>(entity =>
            {
                entity.ToTable("tblPatientAllergyDiagnosis");

                entity.HasKey(e => e.PatientAllergyDiagnosisId);

                entity.Property(e => e.PatientAllergyDiagnosisId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });

            modelBuilder.Entity<Patient_Medication>(entity =>
            {
                entity.ToTable("tblPatient_Medication");

                entity.HasKey(e => e.Patient_MedsId);

                entity.Property(e => e.Patient_MedsId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });


            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.ToTable("tblAllergy");

                entity.HasKey(e => e.AllergyId);

                entity.Property(e => e.AllergyId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<PatientVitals>(entity =>
            {
                entity.ToTable("tblPatientVitals");

                entity.HasKey(e => e.VitalsId);

                entity.Property(e => e.VitalsId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<Referral>(entity =>
            {
                entity.ToTable("tblReferral");

                entity.HasKey(e => e.ReferralId);

                entity.Property(e => e.ReferralId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });
            modelBuilder.Entity<WalkIn>(entity =>
            {
                entity.ToTable("tblWalkIn");

                entity.HasKey(e => e.WalkInId);

                entity.Property(e => e.WalkInId).HasMaxLength(50)
                .HasDefaultValueSql("(newid())");

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasMaxLength(50)
               .HasDefaultValueSql("(newid())");

                entity.ToTable("tblCity");

                entity.Property(e => e.CityId).ValueGeneratedOnAdd();

                entity.Property(e => e.CityName)
                                    .IsRequired()
                                    .HasMaxLength(50);

            });
            
            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.ClinicId);

                entity.Property(e => e.ClinicId).HasMaxLength(50)
              .HasDefaultValueSql("(newid())");

                entity.ToTable("tblClinic");

                entity.Property(e => e.ClinicName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblClinic)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblClinic_tblCity");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblClinic)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblClinic_tblProvince");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasMaxLength(50)
              .HasDefaultValueSql("(newid())");

                entity.ToTable("tblDepartment");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.HasKey(e => e.DiagnosisCode);

                entity.Property(e => e.DiagnosisCode).HasMaxLength(50)
             .HasDefaultValueSql("(newid())");

                entity.ToTable("tblDiagnosis");

            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictId);

                entity.Property(e => e.DistrictId).HasMaxLength(50)
             .HasDefaultValueSql("(newid())");

                entity.ToTable("tblDistrict");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblDistrict)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDistrict_tblProvince");
            });
            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId);

                entity.Property(e => e.HospitalId).HasMaxLength(50)
            .HasDefaultValueSql("(newid())");

                entity.ToTable("tblHospital");

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblHospital)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHospital_tblCity");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblHospital)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHospital_tblProvince");
            });
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId);

                entity.Property(e => e.PrescriptionId).HasMaxLength(50)
                        .HasDefaultValueSql("(newid())");

                entity.ToTable("tblPrescription");

            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinceId);

                entity.Property(e => e.ProvinceId).HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.ToTable("tblProvince");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            //stored procedures for 2021 appointments

            modelBuilder
       .Entity<Jan>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_JanStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
       .Entity<Feb>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_FebStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
       .Entity<Mar>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_MarStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
      .Entity<Apr>(entity =>
      {
          entity.HasNoKey();
          entity.ToSqlQuery("sp_AprStats");
          entity.Property(v => v.Total).HasColumnName("Total");

      });
            modelBuilder
       .Entity<May>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_MaybStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
       .Entity<Jun>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_JunStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
      .Entity<Jul>(entity =>
      {
          entity.HasNoKey();
          entity.ToSqlQuery("sp_JulStats");
          entity.Property(v => v.Total).HasColumnName("Total");

      });
            modelBuilder
       .Entity<Aug>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_AugStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
       .Entity<Sep>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_SeptStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
      .Entity<Oct>(entity =>
      {
          entity.HasNoKey();
          entity.ToSqlQuery("sp_OctStats");
          entity.Property(v => v.Total).HasColumnName("Total");

      });
            modelBuilder
       .Entity<Nov>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_NovStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });
            modelBuilder
       .Entity<Dec>(entity =>
       {
           entity.HasNoKey();
           entity.ToSqlQuery("sp_DecStats");
           entity.Property(v => v.Total).HasColumnName("Total");

       });

            //for 2021 approved appointments

            modelBuilder
    .Entity<JR>(entity =>
    {
        entity.HasNoKey();
        entity.ToSqlQuery("sp_JanAppr");
        entity.Property(v => v.Total).HasColumnName("Total");

    });
            modelBuilder
     .Entity<FR>(entity =>
     {
         entity.HasNoKey();
         entity.ToSqlQuery("sp_FebAppr");
         entity.Property(v => v.Total).HasColumnName("Total");

     });
            modelBuilder
     .Entity<MR>(entity =>
     {
         entity.HasNoKey();
         entity.ToSqlQuery("sp_MarAppr");
         entity.Property(v => v.Total).HasColumnName("Total");

     });
            modelBuilder
     .Entity<AR>(entity =>
     {
         entity.HasNoKey();
         entity.ToSqlQuery("sp_AprAppr");
         entity.Property(v => v.Total).HasColumnName("Total");

     });
            modelBuilder
    .Entity<MA>(entity =>
    {
        entity.HasNoKey();
        entity.ToSqlQuery("sp_MayAppr");
        entity.Property(v => v.Total).HasColumnName("Total");

    });
            modelBuilder
               .Entity<JU>(entity =>
               {
                   entity.HasNoKey();
                   entity.ToSqlQuery("sp_JunAppr");
                   entity.Property(v => v.Total).HasColumnName("Total");

               });
            modelBuilder
   .Entity<JL>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_JulAppr");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
   .Entity<AU>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_AugAppr");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
   .Entity<SE>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_SepAppr");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
               .Entity<OC>(entity =>
               {
                   entity.HasNoKey();
                   entity.ToSqlQuery("sp_OctAppr");
                   entity.Property(v => v.Total).HasColumnName("Total");

               });
            modelBuilder
   .Entity<NO>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_NovAppr");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
   .Entity<DE>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_DecAppr");
       entity.Property(v => v.Total).HasColumnName("Total");

   });

            //2021 cancelled appointments

            modelBuilder
    .Entity<JA>(entity =>
    {
        entity.HasNoKey();
        entity.ToSqlQuery("sp_JanC");
        entity.Property(v => v.Total).HasColumnName("Total");

    });
            modelBuilder
     .Entity<FE>(entity =>
     {
         entity.HasNoKey();
         entity.ToSqlQuery("sp_FebC");
         entity.Property(v => v.Total).HasColumnName("Total");

     });
            modelBuilder
     .Entity<MAR>(entity =>
     {
         entity.HasNoKey();
         entity.ToSqlQuery("sp_MarC");
         entity.Property(v => v.Total).HasColumnName("Total");

     });
            modelBuilder
     .Entity<AP>(entity =>
     {
         entity.HasNoKey();
         entity.ToSqlQuery("sp_AprC");
         entity.Property(v => v.Total).HasColumnName("Total");

     });
            modelBuilder
    .Entity<MY>(entity =>
    {
        entity.HasNoKey();
        entity.ToSqlQuery("sp_MayC");
        entity.Property(v => v.Total).HasColumnName("Total");

    });
            modelBuilder
               .Entity<JN>(entity =>
               {
                   entity.HasNoKey();
                   entity.ToSqlQuery("sp_JunC");
                   entity.Property(v => v.Total).HasColumnName("Total");

               });
            modelBuilder
   .Entity<JUL>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_JulC");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
   .Entity<AUGU>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_AugC");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
   .Entity<SEPT>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_SepC");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
               .Entity<OCT>(entity =>
               {
                   entity.HasNoKey();
                   entity.ToSqlQuery("sp_OctC");
                   entity.Property(v => v.Total).HasColumnName("Total");

               });
            modelBuilder
   .Entity<NOV>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_NovC");
       entity.Property(v => v.Total).HasColumnName("Total");

   });
            modelBuilder
   .Entity<DEC>(entity =>
   {
       entity.HasNoKey();
       entity.ToSqlQuery("sp_DecC");
       entity.Property(v => v.Total).HasColumnName("Total");

   });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<OCMS03.Models.Content.PatientVitals> PatientVitals { get; set; }

        public DbSet<OCMS03.Models.Content.Referral> Referral { get; set; }

    }
}