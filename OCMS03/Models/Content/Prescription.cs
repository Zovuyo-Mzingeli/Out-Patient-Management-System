using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public partial class Prescription
    {
        [Key]
        public string PrescriptionId { get; set; }
        [Required]
        public string PatientId { get; set; }
        public virtual ApplicationUser Patient { get; set; }

        public string PharmacistId { get; set; }
        public virtual ApplicationUser Pharmacist { get; set; }

        [Required]
        public string StaffId { get; set; }
        public virtual ApplicationUser DoctorOrNurse { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(1000)]
        [MinLength(7)]
        public string PrescriptionNotes { get; set; }
        public bool SeenByPharmacist { get; set; } 

        [NotMapped]
        public string PrescriptionWithPatient
        {
            get
            {
                return string.Format("{0} ({1})", PrescriptionId, Date);
            }
        }
        //public ICollection<Patient_Prescription> Patient_Prescription { get; set; }
        
    }
}
