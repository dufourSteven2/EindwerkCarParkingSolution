
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EindwerkCarParkingCore.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EindwerkCarParkingContext>
    {
        public EindwerkCarParkingContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<EindwerkCarParkingContext>();
            var connectionString = "server=(localdb)\\MSSQLLocalDB; Database=TestData; Integrated Security=true;; MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            return new EindwerkCarParkingContext(builder.Options);
        }
    }
}
