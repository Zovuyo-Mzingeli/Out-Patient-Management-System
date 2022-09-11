using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Content
{
    public class Medication
    {
        [Key]
        public string MedicationId { get; set; }
        [Required]
        [MinLength(3)]
        public string RegistryNo { get; set; }
        [Required]
        [MinLength(3)]
        public string ProductName { get; set; }
        [Required]
        [MinLength(3)]
        public string ActiveIngredients { get; set; }
        [Required]
        public string StrengthOrPacksize { get; set; }
        [Required]
        public string PackSize { get; set; }
        [Required]
        [MinLength(2)]
        public string Form { get; set; }
        [Required]
        public string Schedule { get; set; }
        [Required]
        [MinLength(3)]
        public string QuantityAndLimitation { get; set; }
        [Required]
        [MinLength(3)]
        public string Manufacturer { get; set; }
        [Required]
        public DateTime MedExpirationDate { get; set; }
        //public ICollection<Patient_Prescription> Patient_Prescription { get; set; }

        
        public string MedDetails
        {
            get
            {
                return ProductName + ", " + ActiveIngredients + ", " + Form;
            }
        }
    }
}
