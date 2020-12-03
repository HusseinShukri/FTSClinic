using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatientRegistrySystem.DB.Contexts;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.Cookies;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.DB.Repos.AdminRepository;
using PatientRegistrySystem.DB.Repos.DoctorRepository;
using PatientRegistrySystem.DB.Repos.EmployeeRepository;
using PatientRegistrySystem.DB.Repos.PationrRepository;
using PatientRegistrySystem.Services.PatientServices;
using PatientRegistrySystem.Services.AdminServices;
using System;
using System.Reflection;
using System.IO;
using PatientRegistrySystem.DB.Models;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Services.DoctorServices;
using PatientRegistrySystem.Services.EmployeeServices;

namespace PatientRegistrySystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddProblemDetails();
            //rpos
            services.AddScoped<IAplicationUserRepository, AplicationUserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            //services
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPatientService, PatientService>();

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("ClinicOpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "FTS Clinic API",
                        Version = "1",
                        Description = "Through this API you can access Users and their roles",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "Hussein00Shukri@hotmail.com",
                            Name = "Hussein Shukri",
                            Url = new Uri("https://github.com/HusseinShukri/FTSClinic")
                        }
                    });
                var xmlCommentFiles = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFiles);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);

            });

            services.AddAutoMapper(typeof(DB.Profiles.MapperProfile).Assembly
                , typeof(Profiles.MapperProfile).Assembly);

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data Source=DESKTOP-0CVKC97;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog = PatientRegistrySystem",
                b => b.MigrationsAssembly("PatientRegistrySystem.DB"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseProblemDetails();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "ClinicOpenAPISpecification/swagger.json",
                    "Clinic API");
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
