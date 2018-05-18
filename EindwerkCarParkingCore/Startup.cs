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

namespace EindwerkCarParkingCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EindwerkCarParkingContext>(cfg=>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("EindwerkCarParkingString"));
            });
            services.AddTransient<lMailService, NullMailService>();
            //support for real mail  servie
            services.AddTransient<ParkingSeeder>();
            services.AddMvc();

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
                    seeder.Seed();
                }
            }
        }
    }
}
