using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Appointment
    {
        [Key]
        public string AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Today;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose start time your appointment")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter description your appointment")]
        [MaxLength(250)]
        [MinLength(3)]
        public string AppointmentDescription { get; set; }
        public bool isConfirmed { get; set; }
        public string DoctorId { get; set; }
        public string NurseId { get; set; }
        public string PatientId { get; set; }
        public string HospitalId { get; set; }
        [Required]
        public string ClinicId { get; set; }
        public string WalkInId { get; set; }
        public bool IsDone { get; set; } = false;
        public char apptStatus { get; set; } = 'A';
        public virtual ApplicationUser Doctor { get; set; }
        public virtual ApplicationUser Nurse { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual WalkIn WalkIn { get; set; }

        public virtual ICollection<Diagnosis> TblDiagnosis { get; set; }

    }
    //stores data for stored procedure
    //2021 appointments
    public class Jan
        {
            public int Total { get; set; }
        }
        public class Feb
        {
            public int Total { get; set; }
        }
        public class Mar
        {
            public int Total { get; set; }
        }
        public class Apr
        {
            public int Total { get; set; }
        }
        public class May
        {
            public int Total { get; set; }
        }
        public class Jun
        {
            public int Total { get; set; }
        }
        public class Jul
        {
            public int Total { get; set; }
        }
        public class Aug
        {
            public int Total { get; set; }
        }
        public class Sep
        {
            public int Total { get; set; }
        }
        public class Oct
        {
            public int Total { get; set; }
        }
        public class Nov
        {
            public int Total { get; set; }
        }
        public class Dec
        {
            public int Total { get; set; }
        }
    //2021 Approved appointments
    public class JR
    {
        public int Total { get; set; }
    }
    public class FR
    {
        public int Total { get; set; }
    }
    public class MR
    {
        public int Total { get; set; }
    }
    public class AR
    {
        public int Total { get; set; }
    }
    public class MA
    {
        public int Total { get; set; }
    }
    public class JU
    {
        public int Total { get; set; }
    }
    public class JL
    {
        public int Total { get; set; }
    }
    public class AU
    {
        public int Total { get; set; }
    }
    public class SE
    {
        public int Total { get; set; }
    }
    public class OC
    {
        public int Total { get; set; }
    }
    public class NO
    {
        public int Total { get; set; }
    }
    public class DE
    {
        public int Total { get; set; }
    }
    //cancelled appointments
    public class JA
    {
        public int Total { get; set; }
    }
    public class FE
    {
        public int Total { get; set; }
    }
    public class MAR
    {
        public int Total { get; set; }
    }
    public class AP
    {
        public int Total { get; set; }
    }
    public class MY
    {
        public int Total { get; set; }
    }
    public class JN
    {
        public int Total { get; set; }
    }
    public class JUL
    {
        public int Total { get; set; }
    }
    public class AUGU
    {
        public int Total { get; set; }
    }
    public class SEPT
    {
        public int Total { get; set; }
    }
    public class OCT
    {
        public int Total { get; set; }
    }
    public class NOV
    {
        public int Total { get; set; }
    }
    public class DEC
    {
        public int Total { get; set; }
    }
}

