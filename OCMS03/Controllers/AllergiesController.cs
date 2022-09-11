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
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class AllergiesController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;

        public AllergiesController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.tblAllergy.ToListAsync());
        }

        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
                return View(new Allergy());
            else
            {
                var allergies = await context.tblDepartment.FindAsync(id);
                if (allergies == null)
                {
                    return NotFound();
                }
                return View(allergies);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string AllergyTypeName, [Bind("AllergyId,AllergyTypeName")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblAllergy.Where(p => p.AllergyTypeName.Equals(AllergyTypeName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(allergy);
                            await context.SaveChangesAsync();
                            Notify(allergy.AllergyTypeName + " allergy was added successfully");
                        }
                        else
                        {
                            Notify(item.AllergyTypeName + " already existing in the database", notificationType: NotificationType.error);
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
                        context.Update(allergy);
                        await context.SaveChangesAsync();
                        Notify(allergy.AllergyTypeName + " allergy was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AllergyExists(allergy.AllergyId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index), allergy);
            }
            return View(allergy);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var allergy = await context.tblAllergy.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.tblAllergy.Remove(allergy);
                    await context.SaveChangesAsync();
                    Notify(allergy.AllergyTypeName + " allergy was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(allergy.AllergyTypeName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AllergyExists(string id)
        {
            return context.tblAllergy.Any(e => e.AllergyId == id);
        }
    }
}
