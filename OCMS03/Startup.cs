using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OCMS03.Data;
using OCMS03.Models;
using OCMS03.Models.Repositories.BookingRepositories;
using OCMS03.Models.Repositories.ExamRepositories;
using OCMS03.Models.Repositories.PatientMedRepositories;
using OCMS03.Models.Repositories.PrescriptionRepositories;
using OCMS03.Models.Repositories.ProfileImage;
using OCMS03.Services;
using ReflectionIT.Mvc.Paging;

namespace OCMS03
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Account/Login";
                 });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => 
            {
                options.Stores.MaxLengthForKeys = 128;
                options.User.RequireUniqueEmail = true;
                //opts.SignIn.RequireConfirmedEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                //opts.Password.RequiredLength = 6;
                //opts.Password.RequireNonAlphanumeric = false;
                //opts.Password.RequireLowercase = false;
                //opts.Password.RequireUppercase = false;
                //opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<OCMS03_TheCollectiveContext>().AddDefaultTokenProviders();

            services.AddDbContext<OCMS03_TheCollectiveContext>(options =>
            options.UseSqlServer(Configuration["Data:ConnectionString:OCMS03DB"]));
            //services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();

           
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IExaminationRepository, ExaminationRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            services.AddTransient<IVitalsRepository, VitalsRepository>();
            services.AddTransient<IPatientMedRepository, PatientMedRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddPaging();

            services.AddAutoMapper();
            services.AddControllersWithViews();
            services.AddMvc().AddXmlSerializerFormatters();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(20);
                opts.Cookie.HttpOnly = true;
            });
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware(typeof(VisitorCounterMiddleware));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                ///endpoints.MapRazorPages();
            });
            //await RoleConfiguration.Initial(roleManager);
        }
    }
}
