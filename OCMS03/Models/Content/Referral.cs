using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public class Referral
    {
        [Key]
        public string ReferralId { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string StaffId { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public string ReferalDescriptin { get; set; }
        [Required]
        public string DepartmentId { get; set; }

        public virtual ApplicationUser Staff { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual Department Department { get; set; }
    }
}
