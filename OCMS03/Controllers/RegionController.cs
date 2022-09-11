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

namespace OCMS03.Controllers
{
    public class RegionController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        public RegionController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblDistrict
            .Include(c => c.Province)
            .AsNoTracking());
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                PopulateProvinceDropDownList();
                return View(new District());
            }
            else
            {
                PopulateProvinceDropDownList();
                var region = await context.tblDistrict.FindAsync(id);
                if (region == null)
                {
                    return NotFound();
                }
                return View(region);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string DistrictName, [Bind("DistrictId,DistrictName,ProvinceId")] District region)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblDistrict.Where(p => p.DistrictName.Equals(DistrictName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(region);
                            await context.SaveChangesAsync();
                            Notify(region.DistrictName + " district was added successfully");
                        }
                        else
                        {
                            Notify(item.DistrictName + " already existing in the database", notificationType: NotificationType.error);
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
                        PopulateProvinceDropDownList(region.ProvinceId);
                        context.Update(region);
                        await context.SaveChangesAsync();
                        Notify(region.DistrictName + " district was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(region.DistrictId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index), region);
            }
            return View(region);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var district = await context.tblDistrict.FindAsync(id);
            try
            {
                if (id != null)
                {
                    context.tblDistrict.Remove(district);
                    await context.SaveChangesAsync();
                    Notify(district.DistrictName + " district was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(district.DistrictName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ModelExists(string id)
        {
            return context.tblDistrict.Any(e => e.DistrictId == id);
        }
      
        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var provinceQuery = from d in context.tblProvince
                                   orderby d.ProvinceName
                                   select d;
            ViewBag.ProvinceId = new SelectList(provinceQuery.AsNoTracking(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
    }
}
