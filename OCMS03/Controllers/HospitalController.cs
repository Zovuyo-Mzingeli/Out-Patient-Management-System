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
    public class HospitalController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        public HospitalController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult SearchHospital()
        {
            return View(context.tblHospital
                  .Include(c => c.City)
                  .Include(c => c.Province)
                  .AsNoTracking());
        }
        [HttpGet]
        public IActionResult FindHospital()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(context.tblHospital
                .Include(c => c.City)
                .Include(c => c.Province)
                .AsNoTracking());
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                PopulateProvinceDropDownList();
                PopulateCityDropDownList();
                return View(new Hospital());
            }
            else
            {
                PopulateProvinceDropDownList();
                PopulateCityDropDownList();
                var hospital = await context.tblHospital.FindAsync(id);
                if (hospital == null)
                {
                    return NotFound();
                }
                return View(hospital);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string HospitalName, [Bind("HospitalId,HospitalName,AddressLine1,AddressLine2,ProvinceId,CityId,PostalCode,Telephone,FaxNumber")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblHospital.Where(p => p.HospitalName.Equals(HospitalName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(hospital);
                            await context.SaveChangesAsync();
                            Notify(hospital.HospitalName + " hospital was added successfully");
                        }
                        else
                        {
                            Notify(item.HospitalName + " already existing in the database", notificationType: NotificationType.error);
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
                        PopulateProvinceDropDownList(hospital.ProvinceId);
                        PopulateCityDropDownList(hospital.CityId);
                        context.Update(hospital);
                        await context.SaveChangesAsync();
                        Notify(hospital.HospitalName + " hospital was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(hospital.HospitalId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var hospital = await context.tblHospital.FindAsync(id);
            try
            {
                if (id != null)
                {
                    PopulateProvinceDropDownList(hospital.ProvinceId);
                    PopulateCityDropDownList(hospital.CityId);
                    context.tblHospital.Remove(hospital);
                    await context.SaveChangesAsync();
                    Notify(hospital.HospitalName + " hospital was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(hospital.HospitalName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ModelExists(string id)
        {
            return context.tblHospital.Any(e => e.HospitalId == id);
        }

        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var provinceQuery = from d in context.tblProvince
                                orderby d.ProvinceName
                                select d;
            ViewBag.ProvinceId = new SelectList(provinceQuery.AsNoTracking(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from d in context.tblCity
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
    }
}
