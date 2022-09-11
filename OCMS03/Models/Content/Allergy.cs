using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public class Allergy
    {
        [Key]
        public string AllergyId { get; set; }
        [Required]
        [MinLength(3)]
        public string AllergyTypeName { get; set; }

        public virtual ICollection<Patient_AllergyDiagnosis> AllergyDiagnosis { get; set; }
    }
}
