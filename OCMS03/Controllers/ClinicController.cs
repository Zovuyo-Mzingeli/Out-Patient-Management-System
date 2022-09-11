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
using OCMS03.Models.ViewModels.ClinicViewModel;

namespace OCMS03.Controllers
{
    public class ClinicController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        public ClinicController(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult SearchClinic()
        {
            return View(context.tblClinic
                .Include(c => c.City)
                .Include(c => c.Province)
                .AsNoTracking());
        }
        [HttpGet]
        public IActionResult FindClinic() 
        {
            PopulateProvinceDropDownList();
            PopulateCityDropDownList();
            return View();
        }
        [HttpPost]
        public IQueryable<Clinic> FindClinic(SearchClinic searchModel)
        {
            PopulateProvinceDropDownList();
            PopulateCityDropDownList();
            var result = context.tblClinic.AsQueryable();
            if (searchModel != null)
            {
                result = result.Where(x => x.ClinicId == searchModel.Id);

                if (!string.IsNullOrEmpty(searchModel.province))
                    result = result.Where(x => x.ProvinceId.Contains(searchModel.province));

                if (!string.IsNullOrEmpty(searchModel.city))
                    result = result.Where(x => x.CityId.Contains(searchModel.city));

                if (!string.IsNullOrEmpty(searchModel.clinic))
                    result = result.Where(x => x.ClinicName.Contains(searchModel.clinic));
            }
            return result;
        }
        public IActionResult Index()
        {
            return View(context.tblClinic
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
                return View(new Clinic());
            }
            else
            {
                PopulateProvinceDropDownList();
                PopulateCityDropDownList();
                var clinic = await context.tblClinic.FindAsync(id);
                if (clinic == null)
                {
                    return NotFound();
                }
                return View(clinic);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string id, string ClinicName, [Bind("ClinicId,ClinicName,AddressLine1,AddressLine2,ProvinceId,CityId,PostalCode,Telephone,FaxNumber")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblClinic.Where(p => p.ClinicName.Equals(ClinicName)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(clinic);
                            await context.SaveChangesAsync();
                            Notify(clinic.ClinicName + " clinic was added successfully");
                        }
                        else
                        {
                            Notify(item.ClinicName + " already existing in the database", notificationType: NotificationType.error);
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
                        PopulateProvinceDropDownList(clinic.ProvinceId);
                        PopulateCityDropDownList(clinic.CityId);
                        context.Update(clinic);
                        await context.SaveChangesAsync();
                        Notify(clinic.ClinicName + " clinic was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(clinic.ClinicId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clinic);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var clinic = await context.tblClinic.FindAsync(id);
            try
            {
                if (id != null)
                {
                    PopulateProvinceDropDownList(clinic.ProvinceId);
                    PopulateCityDropDownList(clinic.CityId);
                    context.tblClinic.Remove(clinic);
                    await context.SaveChangesAsync();
                    Notify(clinic.ClinicName + " clinic was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify(clinic.ClinicName + " is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(string id)
        {
            return context.tblClinic.Any(e => e.ClinicId == id);
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
