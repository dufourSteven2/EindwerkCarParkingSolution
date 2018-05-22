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
                }).AddEntityFrameworkStores<EindwerkCarParkingContext>();
            
            //services.AddAutoMapper(); //automapper
            //services.AddMvc();

            services.AddDbContext<EindwerkCarParkingContext>(cfg=>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("EindwerkCarParkingString"));
            });
            services.AddTransient<lMailService, NullMailService>();
            //support for real mail  servie
            services.AddTransient<ParkingSeeder>();

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

            });
            

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
