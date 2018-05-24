using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingCore.Services;
using EindwerkCarParkingCore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EindwerkCarParkingCore.Automapper;
using EindwerkCarParkingCore.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EindwerkCarParkingCore
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add identity serverice
            services.AddIdentity<ParkingUser, IdentityRole>(
                cfg =>
                {
                    cfg.User.RequireUniqueEmail = true;
                    cfg.SignIn.RequireConfirmedEmail = true;  //emailbevestiging vereisen

                }).AddEntityFrameworkStores<EindwerkCarParkingContext>().AddDefaultTokenProviders();

            services.AddAuthentication()  //support van 2 soorten authentificatie
    .AddCookie()   //coockie authentication
    .AddJwtBearer(cfg =>
    {
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = Configuration["Tokens:Issuer"],
            ValidAudience = Configuration["Tokens:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
        };

    });   //tokens authentication

            services.AddDbContext<EindwerkCarParkingContext>(cfg=>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("EindwerkCarParkingString"));
            });


            services.AddTransient<lMailService, NullMailService>();

            //support for real mail  servie
            services.AddTransient<ParkingSeeder>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IParkingRepository, ParkingRepository>(); //door in scope dit te plaatsen wordt deze aangesproken wanneer het gevraagd word
            //hierna volgt code voor automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);//einde automapper toevoeging



            services.AddMvc(opt =>
            {
                if (_env.IsProduction())
                {
                    opt.Filters.Add(new RequireHttpsAttribute());  //Https op website wanneer die in productie gaat
                }

            }).AddJsonOptions(opt=> opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            if (env.IsDevelopment())
            {
                //seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<ParkingSeeder>();
                    seeder.Seed().Wait();
                }
            }
        }
    }
}
