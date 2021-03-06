﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using API.Services;
using API.Controllers;
using API.Repositories;
using Newtonsoft.Json;
using API.Configuration;
using Serilog;
using API.ActionFilter;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("C:/Logs/Api.txt", outputTemplate: "{Message:lj}{NewLine}")
                .CreateLogger();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=BigDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ApiDbContext>
                (options => options.UseSqlServer(connection));

            services.AddLogging();

            services.AddSingleton<IDataSerializer<AuthenticationTicket>, TicketSerializer>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(o =>
                    {
                        o.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                        o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                    })
                .AddGoogle(o =>
                    {
                        o.ClientId = "536082131203-00r94akb0omi6qdsuvs2u7rcfenhmi47.apps.googleusercontent.com";
                        o.ClientSecret = "xfIcqv3AItFZjWMvZa4qZttS";
                        o.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                        o.ClaimActions.Clear();
                        o.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                        o.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                        o.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                        o.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                        o.ClaimActions.MapJsonKey("urn:google:profile", "link");
                        o.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                        o.SaveTokens = true;
                        o.Scope.Add("https://www.googleapis.com/auth/calendar");
                        o.Scope.Add("https://www.googleapis.com/auth/calendar.readonly");
                        o.Events.OnCreatingTicket += AuthController.Callback;
                    })
                .AddCookie(o =>
                {
                    o.ExpireTimeSpan = System.TimeSpan.FromHours(1);
                });

            services.Configure<MailOptions>(Configuration.GetSection("Mail"));
            services.AddSingleton<IMailSender, MailSender>();

            services.AddHttpContextAccessor();

            //services.EnableSimpleProxy(p => p
            //    .AddInterceptor<LogAttribute, LogInterceptor>());

            services.AddHttpClient<IGoogleCalendarService, GoogleCalendarService>();
            //services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();

            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<Office>, OfficeRepository>();
            services.AddScoped<IRepository<Event>, EventRepository>();
            services.AddScoped<IRepository<EmployeeToTrip>, EmployeeToTripRepository>();
            services.AddScoped<IRepository<Apartment>, ApartmentRepository>();
            services.AddScoped<IRepository<Reservation>, ReservationRepository>();
            services.AddScoped<IRepository<GasCompensation>, GasCompensationRepository>();
            services.AddScoped<IRepository<CarRental>, CarRentalRepository>();
            services.AddScoped<IRepository<PlaneTicket>, PlaneTicketRepository>();
            services.AddScoped<IRepository<Trip>, TripRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<ITripService, TripService>();
            services.Decorate<ITripService, TripSenderServiceDecorator>();
            services.AddScoped<IEmployeeToTripService, EmployeeToTripService>();
            services.AddScoped<IOfficeApartmentService, OfficeApartmentService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<ITripMerge, TripMerge>();

            services.AddTransient<LogActionFilter>();

            services.AddMvc(options => options.Filters.AddService<LogActionFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
