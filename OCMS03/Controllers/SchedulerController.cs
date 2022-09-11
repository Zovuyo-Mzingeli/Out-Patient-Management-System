using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Extensions;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories.BookingRepositories;
using OCMS03.Models.ViewModels;
using OCMS03.Models.ViewModels.AssignSpecialistViewModel;
using OCMS03.Models.ViewModels.DoctorViewModel;
using OCMS03.Models.ViewModels.PatientViewModel;
using OCMS03.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Controllers
{
    public class SchedulerController : BaseController
    {
        private readonly OCMS03_TheCollectiveContext context;
        private readonly IBookingRepository bookingRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;

        public SchedulerController(OCMS03_TheCollectiveContext context, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            this.context = context;
            this.bookingRepository = bookingRepository;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }
       
        public async Task<IActionResult> Appointments()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);

            var appointments = await bookingRepository.PatientAppointmentsAsync(currentUser.Id);
            var patientAppointmentsViewList = appointments.Select(a => new PatientAppointmentsListViewModel
            {
                AppointmentDescription = a.AppointmentDescription,
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsConfirmed = a.isConfirmed,
                ClinicName = a?.Clinic?.ClinicName,
                PatientName = a?.Patient?.LastName,
                HospitalName = a?.Hospital?.HospitalName ?? "<Not Transfered>",
                NurseName = a?.Nurse?.LastName ?? "<Not Assigned>",
                DoctorName = a?.Doctor?.LastName ?? "<Not Assigned>"
            })
            .ToList();

            return View(patientAppointmentsViewList);
        }
        public async Task<IActionResult> AllAppointments()
        {
            var appointments = await bookingRepository.AllPatientAppointmentsAsync();
            var patientAppointmentsViewList = appointments.Select(a => new PatientAppointmentsListViewModel
            {
                AppointmentDescription = a.AppointmentDescription,
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsConfirmed = a.isConfirmed,
                ClinicName = a?.Clinic?.ClinicName,
                PatientName = a?.Patient?.LastName ?? "<Walk-In Patient>",
                HospitalName = a?.Hospital?.HospitalName ?? "<Not Transfered>",
                NurseName = a?.Nurse?.LastName ?? "<Not Assigned>",
                DoctorName = a?.Doctor?.LastName ?? "<Not Assigned>"
            })
            .ToList();

            return View(patientAppointmentsViewList);
        }
        public async Task<IActionResult> AllUnconfirmedAppointments()
        {
            var appointments = await bookingRepository.AllUnconfirmedAppointmentsAsync();
            var patientAppointmentsViewList = appointments.Select(a => new PatientAppointmentsListViewModel
            {
                AppointmentId = a.AppointmentId,
                AppointmentDescription = a.AppointmentDescription,
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsConfirmed = a.isConfirmed,
                ClinicName = a?.Clinic?.ClinicName,
                PatientName = a?.Patient?.LastName ?? "<Walk-In Patient>",
                HospitalName = a?.Hospital?.HospitalName ?? "<Not Transfered>",
                NurseName = a?.Nurse?.LastName ?? "<Not Assigned>",
                DoctorName =  a?.Doctor?.LastName ?? "<Not Assigned>"
            })
            .ToList();

            return View(patientAppointmentsViewList);
        }
        public async Task<IActionResult> AllConfirmedAppointments()
        {
            var appointments = await bookingRepository.AllConfirmedAppointmentsAsync();
            var patientAppointmentsViewList = appointments.Select(a => new PatientAppointmentsListViewModel
            {
                AppointmentId = a.AppointmentId,
                AppointmentDescription = a.AppointmentDescription,
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                IsConfirmed = a.isConfirmed,
                ClinicName = a?.Clinic?.ClinicName,
                PatientName = a?.Patient?.LastName ?? "<Walk-In Patient>",
                HospitalName = a?.Hospital?.HospitalName ?? "<Not Transfered>",
                NurseName = a?.Nurse?.LastName ?? "<Not Assigned>",
                DoctorName = a?.Doctor?.LastName ?? "<Not Assigned>"
            })
            .ToList();

            return View(patientAppointmentsViewList);
        }
        [HttpGet]
        public async Task<IActionResult> RequestAppointment()
        {
            var user = await userManager.GetUserAsync(User);
            if (user.Idnumber == null || user.Dob == null || user.PhoneNumber == null)
            {
                Notify("Please complete your personal information in order to make  an appountment", notificationType: NotificationType.warning);
                return RedirectToAction(nameof(AccountController.EditUser), "Account");
            }
            else
            {
                PopulateClinicDropDownList();
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> RequestAppointment(PatientAppointmentFormViewModel model)
        {

            if (ModelState.IsValid)
            {
                PopulateClinicDropDownList();
                try
                {
                    var isAvailable = await CheckAvailabilityAsync(
                    model.DoctorId,
                    model.AppointmentDate,
                    model.StartTime);


                    if (!isAvailable)
                    {
                        var doctorsListItems = await GetDoctorsListItemsAsync();
                        model.Doctors = doctorsListItems;
                        return View(model);
                    }

                    if (!isAvailable)
                    {
                        var nursesListItems = await GetNursesListItemsAsync();
                        model.Nurses = nursesListItems;
                        return View(model);
                    }

                    var currentUser = await userManager.GetUserAsync(HttpContext.User);

                    await bookingRepository
                    .AddAsync(
                        model.AppointmentDescription,
                        model.AppointmentDate,
                        model.StartTime,
                        model.EndTime,
                        model.ClinicId,
                        currentUser.Id);

                    PopulateClinicDropDownList(model.ClinicId);
                    Notify("You just made a booking! Please keep track of your status!");
                    return RedirectToAction(nameof(SchedulerController.Appointments), "Scheduler");
                }
                catch (Exception)
                {
                    Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> DailySchedule(DateTime date)
        {
            var appointments = await bookingRepository.AppointmentsByDateAsync(date);

            var model = new DoctorScheduleViewModel
            {
                Date = date,
                Appointments = appointments
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DailySchedule(DoctorScheduleViewModel model)
            => RedirectToAction(nameof(DailySchedule), model.Date);
        [HttpGet]
        public IActionResult WorkOnAppointment(string id, MedicalViewModel model)
        {
            var app = bookingRepository.GetAppointment(id);
            if (app != null)
            {
                model.PatientName = app?.Patient?.FullName;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmAppointment(string id, AssignSpecialistToAppointment model)
        {
            if (!ModelState.IsValid)
            {
                PopulateHospitalDropDownList();
                PopulateClinicDropDownList();
                GetPatientByName();
                var doctorsListItems = await GetDoctorsListItemsAsync();
                var nursesListItems = await GetNursesListItemsAsync();
                model.Doctors = doctorsListItems;
                model.Nurses = nursesListItems;

                var app = bookingRepository.GetAppointment(id);
                if (app != null)
                {
                    model.AppointmentDate = app.AppointmentDate;
                    model.AppointmentDescription = app.AppointmentDescription;
                    model.PatientName = app.PatientId;
                    model.StartTime = app.StartTime;
                    model.EndTime = app.Duration;
                    model.NurseId = app.NurseId;
                    model.DoctorId = app.DoctorId;
                    model.IsConfirmed = app.isConfirmed;
                    model.ClinicId = app.ClinicId;
                    model.HospitalId = app.HospitalId;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(AssignSpecialistToAppointment model, string id)
        {

            if (!ModelState.IsValid)
            {
                PopulateHospitalDropDownList();
                PopulateClinicDropDownList();
                var doctorsListItems = await GetDoctorsListItemsAsync();
                var nursesListItems = await GetNursesListItemsAsync();
                model.Doctors = doctorsListItems;
                model.Nurses = nursesListItems;
                Appointment app = bookingRepository.GetAppointment(id);
                if (app != null)
                {
                    app.HospitalId = model.HospitalId;
                    app.DoctorId = model.DoctorId;
                    app.NurseId = model.NurseId;
                    app.isConfirmed = model.IsConfirmed;

                    PopulateHospitalDropDownList(app.HospitalId);
                    bookingRepository.ApproveAndAssignStaff(app);
                }
                ApplicationUser userr = await userManager.FindByIdAsync(app.PatientId);
                model = new AssignSpecialistToAppointment
                {
                    Email = userr.Email
                };

                
                var ctokenlink = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = app.PatientId
                }, protocol: HttpContext.Request.Scheme);

                await emailSender.SendEmailConfirmationAppointmentAsync(userr.Email, ctokenlink);
                Notify("Appointment has been confirmed successfully");
                return RedirectToAction(nameof(SchedulerController.AllUnconfirmedAppointments), "Scheduler");
            }
            return View();
        }
        public IActionResult CancelAppointment(string id)
        {
            Appointment app = bookingRepository.GetAppointment(id);
            if (app != null)
            {
                PopulateClinicDropDownList(app.ClinicId);
                PopulateHospitalDropDownList(app.HospitalId);

                app.apptStatus = 'D';

                bookingRepository.ApproveAndAssignStaff(app);
            }
            return RedirectToAction(nameof(AllAppointments));
        }
        private async Task<IEnumerable<SelectListItem>> GetDoctorsListItemsAsync()
        {
            List<ViewModelUserRole> doctors = new List<ViewModelUserRole>();
            var drs = await userManager.GetUsersInRoleAsync("Doctor");
            var doctorsListItems = drs.Select(dr => new SelectListItem
            {
                Text = $"Dr. {dr.LastName}",
                Value = dr.Id
            })
            .ToList();

            return doctorsListItems;
        }
        private async Task<IEnumerable<SelectListItem>> GetNursesListItemsAsync()
        {
            List<ViewModelUserRole> nurses = new List<ViewModelUserRole>();
            var nurse = await userManager.GetUsersInRoleAsync("Nurse");
            var nursesListItems = nurse.Select(nrs => new SelectListItem
            {
                Text = nrs.LastName,
                Value = nrs.Id
            })
            .ToList();

            return nursesListItems;
        }
        private async Task<bool> CheckAvailabilityAsync(string doctorId, DateTime date, TimeSpan startTime)
        {
            TimeSpan workDayStart = TimeSpan.Parse("08:00");
            TimeSpan workDayEnd = TimeSpan.Parse("18:00");

            if (startTime < workDayStart || startTime > workDayEnd)
            {
                Notify("Choose an hour between 8 AM and 18 PM", notificationType: NotificationType.error);
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConfirmAppointment()
        {
            return View();
        }
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            Appointment app = bookingRepository.GetAppointment(id);
            try
            {
                if (id != null)
                {
                    PopulateClinicDropDownList(app.ClinicId);
                    PopulateHospitalDropDownList(app.HospitalId);
                    context.tblAppointment.Remove(app);
                    await context.SaveChangesAsync();
                    Notify("Appointment was deleted permanently");
                }
            }
            catch (Exception)
            {
                Notify("Appointment is in use could not be deleted!", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private void PopulateClinicDropDownList(object selectedClinicId = null)
        {
            var ClinicQuery = from d in context.tblClinic
                            orderby d.ClinicName
                            select d;
            ViewBag.ClinicId = new SelectList(ClinicQuery.AsNoTracking(), "ClinicId", "ClinicName",
            selectedClinicId);
        }
        private void PopulateHospitalDropDownList(object selectedHospital = null)
        {
            var hospitalQuery = from d in context.tblHospital
                                orderby d.HospitalName
                                select d;
            ViewBag.HospitalId = new SelectList(hospitalQuery.ToList(), "HospitalId", "HospitalName",
            selectedHospital);
        }
        private void GetPatientByName(object selectedPatient = null)
        {
            var patientQuery = from d in context.tblApplicationUser
                               orderby d.LastName
                              select d;
            ViewBag.PatientId = new SelectList(patientQuery.AsNoTracking(), "Id", "LastName",
            selectedPatient);
        }
    }
}