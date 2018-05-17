using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingLib;

namespace EindwerkCarParkingCore.Models
{
    public class EindwerkCarParkingCoreContext : DbContext
    {
        public EindwerkCarParkingCoreContext (DbContextOptions<EindwerkCarParkingCoreContext> options)
            : base(options)
        {
        }

        public DbSet<EindwerkCarParkingLib.Parking> Parking { get; set; }

        public DbSet<EindwerkCarParkingLib.Eigenaar> Eigenaar { get; set; }

        public DbSet<EindwerkCarParkingLib.Gemeente> Gemeente { get; set; }

        public DbSet<EindwerkCarParkingLib.Soort> Soort { get; set; }

        public DbSet<EindwerkCarParkingLib.Locatie> Locatie { get; set; }

        public DbSet<EindwerkCarParkingLib.Totaal> Totaal { get; set; }

        public DbSet<EindwerkCarParkingLib.Land> Land { get; set; }
    }
}
