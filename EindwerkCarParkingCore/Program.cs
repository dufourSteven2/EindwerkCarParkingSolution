using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EindwerkCarParkingCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()              
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //verwijder standaard opties:
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true).AddEnvironmentVariables(); //laatste value true zorgt ervoor dat bij wijzigingen config.json file de server niet moet herstarten

        }
    }
}
