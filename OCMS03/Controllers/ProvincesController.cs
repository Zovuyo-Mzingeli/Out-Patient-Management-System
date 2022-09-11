using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models;
using OCMS03.Models.Content;
using System;
using System.Linq;
using System.Threading.Tasks;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class ProvincesController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;

        public ProvincesController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.tblProvince.ToListAsync());
        }

        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
                return View(new Province());
            else
            {
                var province = await context.tblProvince.FindAsync(id);
                if (province == null)
                {
                    return NotFound();
                }
                return View(province);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string ProvinceName, [Bind("ProvinceId,ProvinceName")] Province province)
        {
            if (ModelState.IsValid)
            {
                
                if (id == null)
                {
                    try
                    {
                        var item = context.tblProvince.Where(p => p.ProvinceName.Equals(ProvinceName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(province);
                            await context.SaveChangesAsync();
                            Notify(province.ProvinceName + " province was added successfully");
                        }
                        else
                        {
                            Notify(item.ProvinceName + " already existing in the database", notificationType: NotificationType.error);
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
                        context.Update(province);
                        await context.SaveChangesAsync();
                        Notify(province.ProvinceName + " province was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProvincesModelExists(province.ProvinceId))
                        { 
                            return NotFound(); 
                        }
                        else
                        { 
                            throw; 
                        }
                    }
                }
                return RedirectToAction(nameof(Index), province);
            }
            return View(province);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
                var province = await context.tblProvince.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.tblProvince.Remove(province);
                    await context.SaveChangesAsync();
                    Notify(province.ProvinceName + " province was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(province.ProvinceName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ProvincesModelExists(string id)
        {
            return context.tblProvince.Any(e => e.ProvinceId == id);
        }
    }
}

//public async Task<IActionResult> SaveData(Department department)
//{
//    try
//    {
//        Department depart = await context.tblDepartment.FirstOrDefaultAsync(e => e.DepartmentId == department.DepartmentId);

//        if (depart == null)
//        {
//            context.tblDepartment.Add(depart);
//            context.SaveChanges();
//            return Json(new { success = true, message = "Data Submitted Successfully" });
//        }
//        else
//        {
//            depart.DepartmentId = department.DepartmentId;
//            depart.DepartmentName = department.DepartmentName;
//            context.tblDepartment.Update(depart);
//            context.SaveChanges();
//            return Json(new { success = true, message = "Data Updated Successfully" });
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//        return Json(new { success = false, message = "Error while saving" });
//    }
//}