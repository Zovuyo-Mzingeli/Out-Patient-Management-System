using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models;
using OCMS03.Models.Content;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        public DepartmentController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.tblDepartment.Include(d => d.Hospital).AsNoTracking().ToListAsync());
        }

        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            PopulateHospitalDropDownList();
            if (id == null)
                return View(new Department());
            else
            {
                var depart = await context.tblDepartment.FindAsync(id);
                if (depart == null)
                {
                    return NotFound();
                }
                return View(depart);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string DepartmentName, [Bind("DepartmentId,DepartmentName, HospitalId, EmailAddress, ContactNumber, FaxNumber")] Department departments)
        {
            PopulateHospitalDropDownList();
            if (ModelState.IsValid)
            {
                PopulateHospitalDropDownList();
                if (id == null)
                {
                    try
                    {
                        var item = context.tblDepartment.Where(p => p.DepartmentName.Equals(DepartmentName)).FirstOrDefault();
                        if (item == null)
                        {
                            PopulateHospitalDropDownList(departments.HospitalId);
                            context.Add(departments);
                            await context.SaveChangesAsync();
                            Notify(departments.DepartmentName + " department was added successfully");
                        }
                        else
                        {
                            Notify(item.DepartmentName + " already existing in the database", notificationType: NotificationType.error);
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
                        PopulateHospitalDropDownList(departments.HospitalId);
                        context.Update(departments);
                        await context.SaveChangesAsync();
                        Notify(departments.DepartmentName + " department was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(departments.DepartmentId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index), departments);
            }
            return View(departments);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var dep = await context.tblDepartment.FindAsync(id);
            try
            {
                if (id != null)
                {
                    PopulateHospitalDropDownList(dep.HospitalId);
                    context.tblDepartment.Remove(dep);
                    await context.SaveChangesAsync();
                    Notify(dep.DepartmentName + " department was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(dep.DepartmentName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(string id)
        {
            return context.tblProvince.Any(e => e.ProvinceId == id);
        }
        private void PopulateHospitalDropDownList(object selectedHospital = null)
        {
            var hospitalQuery = from d in context.tblHospital
                                orderby d.HospitalName
                                select d;
            ViewBag.HospitalId = new SelectList(hospitalQuery.ToList(), "HospitalId", "HospitalName",
            selectedHospital);
        }
    }
}