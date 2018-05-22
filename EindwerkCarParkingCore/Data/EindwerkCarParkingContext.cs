using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindwerkCarParkingLib;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EindwerkCarParkingCore.Data.Entities;

namespace EindwerkCarParkingCore.Data
{
    public class EindwerkCarParkingContext : IdentityDbContext<ParkingUser>
    {
        public EindwerkCarParkingContext(DbContextOptions<EindwerkCarParkingContext> options):base(options)
        {

        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Eigenaar> Eigenaars { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Soort> Soorts { get; set; }
        public DbSet<Gemeente> Gemeentes { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Totaal> Totaals { get; set; }
    }
}
