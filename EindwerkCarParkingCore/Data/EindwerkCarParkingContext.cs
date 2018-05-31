using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindwerkCarParkingLib;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EindwerkCarParkingCore.Models;

namespace EindwerkCarParkingCore.Data
{
    public class EindwerkCarParkingContext : IdentityDbContext<ParkingUsers>
    {
        public EindwerkCarParkingContext(DbContextOptions<EindwerkCarParkingContext> options):base(options)
        {

        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingUsers> Eigenaars { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
       // public DbSet<Soort> Soorts { get; set; }
        public DbSet<Gemeente> Gemeentes { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Totaal> Totaals { get; set; }
        public DbSet<EindwerkCarParkingCore.Models.ParkingsDetailDTO> ParkingsDetailDTO { get; set; }
    }
}
