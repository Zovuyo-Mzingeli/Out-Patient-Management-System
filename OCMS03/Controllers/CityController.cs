using System;
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
    public class CityController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;

        public CityController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.tblCity
                .Include(c => c.District)
                .AsNoTracking());
        }
        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                PopulateDistrctDropDownList();
                return View(new City());
            }
            else
            {
                PopulateDistrctDropDownList();
                var cities = await context.tblCity.FindAsync(id);
                if (cities == null)
                {
                    return NotFound();
                }
                return View(cities);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string CityName, [Bind("CityId,CityName,DistrictId")] City cities)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblCity.Where(p => p.CityName.Equals(CityName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(cities);
                            await context.SaveChangesAsync();
                            Notify(cities.CityName + " city was added successfully");
                        }
                        else
                        {
                            Notify(item.CityName + " already existing in the database", notificationType: NotificationType.error);
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
                        PopulateDistrctDropDownList(cities.DistrictId);
                        context.Update(cities);
                        await context.SaveChangesAsync();
                        Notify(cities.CityName + " city was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(cities.CityId))
                        {
                            return NotFound();
                        }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index), cities);
            }
            return View(cities);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var cities = await context.tblCity.FindAsync(id);
            try
            {
                if (id != null)
                {
                    PopulateDistrctDropDownList(cities.DistrictId);
                    context.tblCity.Remove(cities);
                    Notify(cities.CityName + " city was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(cities.CityName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(string id)
        {
            return context.tblCity.Any(e => e.CityId == id);
        }

        private void PopulateDistrctDropDownList(object selectedDistrictId = null)
        {
            var CityQuery = from d in context.tblDistrict.Distinct().AsNoTracking()
                            orderby d.DistrictName
                            select d;
            ViewBag.DistrictId = new SelectList(CityQuery.AsNoTracking(), "DistrictId", "DistrictName",
            selectedDistrictId);
        }
    }
}