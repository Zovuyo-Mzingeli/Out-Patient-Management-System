using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models.Content;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class DiagnosisController : Controller
    {
        private readonly OCMS03_TheCollectiveContext context;
        public DiagnosisController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var diagnosis = context.tblDiagnosis;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("~/Views/Diagnosis/_ViewAll.cshtml", diagnosis);
            }

            return View(diagnosis);
        }
        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
                return PartialView("~/Views/Diagnosis/_AddPartial.cshtml");
            else
            {
                var diagnosis = await context.tblDiagnosis.FindAsync(id);
                if (diagnosis == null)
                {
                    return NotFound();
                }
                return PartialView("~/Views/Diagnosis/_AddPartial.cshtml", diagnosis);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, [Bind("DiagnosisCode,DiagnosisDescription,DiagnosisComment")] Diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    context.Add(diagnosis);
                    await context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        context.Update(diagnosis);
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(diagnosis.DiagnosisCode))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), diagnosis);
        }
        private bool ModelExists(string id)
        {
            return context.tblDiagnosis.Any(e => e.DiagnosisCode == id);
        }

        public async Task<IActionResult> Delete(string id)
        {
            Diagnosis diagnosis = context.tblDiagnosis.Find(id);
            if (diagnosis != null)
            {
                context.tblDiagnosis.Remove(diagnosis);
                await context.SaveChangesAsync();
                return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", context.tblDiagnosis.ToList()) });
            }
            return View(diagnosis);
        }
        [NonAction]
        private void CreateNotification(string message)
        {
            TempData.TryGetValue("Notifications", out object value);
            var notifications = value as List<string> ?? new List<string>();
            notifications.Add(message);
            TempData["Notifications"] = notifications;
        }

        public IActionResult Notifications()
        {
            TempData.TryGetValue("Notifications", out object value);
            var notifications = value as IEnumerable<string> ?? Enumerable.Empty<string>();
            return PartialView("_NotificationsPartial", notifications);
        }
    }
}
