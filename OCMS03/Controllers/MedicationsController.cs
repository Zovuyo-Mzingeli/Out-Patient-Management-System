using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Content;

namespace OCMS03.Controllers
{
    public class MedicationsController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;

        public MedicationsController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.tblMedication.ToListAsync());
        }

        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
                return View(new Medication());
            else
            {
                var depart = await context.tblMedication.FindAsync(id);
                if (depart == null)
                {
                    return NotFound();
                }
                return View(depart);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string ProductName, [Bind("MedicationId,RegistryNo,ProductName,Manufacturer,ActiveIngredients,StrengthOrPacksize,PackSize,Form,Schedule,QuantityAndLimitation,Manufacturer,MedExpirationDate")] Medication medication)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblMedication.Where(p => p.ProductName.Equals(ProductName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(medication);
                            await context.SaveChangesAsync();
                            Notify(medication.ProductName + " Medication was added successfully");
                        }
                        else
                        {
                            Notify(item.ProductName + " already existing in the database", notificationType: NotificationType.error);
                            return View(item);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    try
                    {
                        context.Update(medication);
                        await context.SaveChangesAsync();
                        Notify(medication.ProductName + " medication was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MedicationExists(medication.MedicationId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index), medication);
            }
            return View(medication);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await context.tblMedication
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var medication = await context.tblMedication.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.tblMedication.Remove(medication);
                    await context.SaveChangesAsync();
                    Notify(medication.ProductName + " medication was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(medication.ProductName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool MedicationExists(string id)
        {
            return context.tblMedication.Any(e => e.MedicationId == id);
        }
    }
}
