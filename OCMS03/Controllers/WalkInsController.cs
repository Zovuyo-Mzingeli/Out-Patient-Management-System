using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories.BookingRepositories;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.DoctorViewModel;
using OCMS03.Models.ViewModels.PatientViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    public class WalkInsController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        private readonly UserManager<ApplicationUser> userManage;
        private readonly IBookingRepository bookingRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public WalkInsController(OCMS03_TheCollectiveContext context, UserManager<ApplicationUser> userManage, IBookingRepository bookingRepository)
        {
            this.context = context;
            this.userManage = userManage;
            this.bookingRepository = bookingRepository;
        }
        public IActionResult Index()
        {
            var walkIns = context.tblWalkIn.ToList();
            return View(walkIns);
        }

        [HttpGet]
        public IActionResult MakeAppointment()
        {
            PopulateWalkInsDropDownList();
            PopulateClinicDropDownList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MakeAppointment(RegisterWalkInsViewModel model)
        {
            PopulateWalkInsDropDownList();
            PopulateClinicDropDownList();
            if (ModelState.IsValid)
            {
                //try
                //{
                    var walkinApp = new Appointment
                    {
                        AppointmentDescription = model.AppointmentDescription,
                        AppointmentDate = model.AppointmentDate,
                        StartTime = model.StartTime,
                        WalkInId = model.WalkInId,
                        ClinicId = model.ClinicId
                    };

                    PopulateClinicDropDownList(walkinApp.ClinicId);
                    PopulateWalkInsDropDownList(walkinApp.WalkInId);

                    await context.AddAsync(walkinApp);
                    await context.SaveChangesAsync();

                    Notify("You just made a booking! Please keep track of your status!");
                    return RedirectToAction(nameof(SchedulerController.Appointments), "Scheduler");
                
                //catch (Exception)
                //{
                //    //Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
                //}
            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> RegisterWalkIn(string id = null)
        {
            if (id == null)
            {
                return View(new WalkIn());
            }
            else
            {
                var walkin = await context.tblWalkIn.FindAsync(id);
                if (walkin == null)
                {
                    return NotFound();
                }
                return View(walkin);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterWalkIn(string id, string idNumber, [Bind("WalkInId,FirstName,LastName,PhoneNumber,Idnumber,Gender,Title,Dob,NextOfName,Relationship,AddressLine1,NextOfName,NextOfKinNumber,NextOfKinSurname")] WalkIn walkin)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    try
                    {
                        var item = context.tblWalkIn.Where(p => p.Idnumber.Equals(idNumber)).FirstOrDefault();
                        if (item == null)
                        {
                            context.Add(walkin);
                            await context.SaveChangesAsync();
                            Notify(walkin.Idnumber + " walkin was added successfully");
                        }
                        else
                        {
                            Notify(item.Idnumber + " already existing in the database", notificationType: NotificationType.error);
                            return View(item);
                        }
                    }
                    catch (Exception)
                    {
                        Notify("Something went wrong please check all neccessary info be provided", notificationType: NotificationType.error);
                    }
                }
                else
                {
                    try
                    {
                        context.Update(walkin);
                        await context.SaveChangesAsync();
                        Notify(walkin.Idnumber + " walkin was updated successfully");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModelExists(walkin.WalkInId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return RedirectToAction(nameof(WalkInsController.MakeAppointment), "WalkIns");
            }
            return View(walkin);
        }
        private bool ModelExists(string id)
        {
            return context.tblWalkIn.Any(e => e.WalkInId == id);
        }
        private async Task<bool> CheckAvailabilityAsync(string doctorId, DateTime date, TimeSpan startTime)
        {
            TimeSpan workDayStart = TimeSpan.Parse("08:00");
            TimeSpan workDayEnd = TimeSpan.Parse("23:00");

            if (startTime < workDayStart || startTime > workDayEnd)
            {
                Notify("Choose an hour between 8 AM and 11 PM", notificationType: NotificationType.error);
                return false;
            }

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                Notify("Choose a date not during the weekend", notificationType: NotificationType.error);
                return false;
            }

            if (DateTime.Now.Date == date && DateTime.Now.TimeOfDay > startTime)
            {
                Notify("You cannot make an appointment in a past hour!", notificationType: NotificationType.error);
                return false;
            }
            if (date < DateTime.Today)
            {
                Notify("You cannot make an appointment in a past day!", notificationType: NotificationType.error);
                return false;
            }

            bool isDoctorAvailable = await this.bookingRepository.CheckAvailability(doctorId, date, startTime);
            if (!isDoctorAvailable)
            {
                Notify("Nurse/Doctor is already booked for this time!", notificationType: NotificationType.error);
            }

            return isDoctorAvailable;
        }
        private async Task<IEnumerable<SelectListItem>> GetPatientsListItemsAsync()
        {
            List<ViewModelUserRole> petients = new List<ViewModelUserRole>();
            var patient = await userManager.GetUsersInRoleAsync("Patient");
            var patientListItems = patient.Select(pts => new SelectListItem
            {
                Text = pts.PersonelDetails,
                Value = pts.Id
            })
            .ToList();

            return patientListItems;
        }
        private void PopulateClinicDropDownList(object selectedClinicId = null)
        {
            var ClinicQuery = from d in context.tblClinic
                              orderby d.ClinicName
                              select d;
            ViewBag.ClinicId = new SelectList(ClinicQuery.AsNoTracking(), "ClinicId", "ClinicName",
            selectedClinicId);
        }
        private void PopulateWalkInsDropDownList(object selectedWalkInId = null)
        {
            var walkinQuery = from d in context.tblWalkIn
                              orderby d.FirstName
                              select d;
            ViewBag.WalkInId = new SelectList(walkinQuery.AsNoTracking(), "WalkInId", "PersonelDetails",
            selectedWalkInId);
        }
    }
}
