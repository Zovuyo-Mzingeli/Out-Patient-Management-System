using Microsoft.AspNetCore.Mvc.Rendering;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Medication medication, string dose, string frequency, string duration, bool morning, bool afternoon, bool evening)
        {
            CartLine line = lineCollection
            .Where(p => p.Medication.MedicationId == medication.MedicationId)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Medication = medication,
                    Dose = dose,
                    Duration = duration,
                    Frequency = frequency,
                    Morning = morning,
                    Afternoon = afternoon,
                    Evening = evening
                });
            }
        }

        public virtual void RemoveLine(Medication medication) =>
        lineCollection.RemoveAll(l => l.Medication.MedicationId == medication.MedicationId);
      
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        [Key]
        public string Patient_PrescriptionId { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Evening { get; set; }

        public Prescription Prescription { get; set; }
        public Medication Medication { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> Patients { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Doctors { get; set; }
    }
}
