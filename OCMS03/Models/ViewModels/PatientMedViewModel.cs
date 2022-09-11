using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OCMS03.Models.CommonMapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.ViewModels
{
    public class PatientMedViewModel : IMapFrom<Patient_Medication>
    {
        [Key]
        public string Patient_MedsId { get; set; }
        public string PatientName { get; set; }
        public string PharmacistName { get; set; }
        public bool MedsReceived { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser Pharmacist { get; set; }
        public ApplicationUser Patient { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
