namespace EindwerkCarParking.Migrations
{
    using EindwerkCarParkingLib;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EindwerkCarParking.Models.EindwerkCarParkingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EindwerkCarParking.Models.EindwerkCarParkingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            

            context.Lands.AddOrUpdate(x => x.Id,
             new Land() { Id = 1, LandNaam = "Belgie" },
             new Land() { Id = 2, LandNaam = "Nederland" }
             );

            context.Gemeentes.AddOrUpdate(x => x.Id,
                new Gemeente() { Id = 1, GemeenteNaam = "Brugge" },
                new Gemeente() { Id = 2, GemeenteNaam = "Gent" },
                new Gemeente() { Id = 3, GemeenteNaam = "Oostende" }
                );

            context.Eigenaars.AddOrUpdate(x => x.Id,
                new Eigenaar() { Id = 1, Email = "nonkelchameau@gmail.com", EigenaarNaam = "Alfapark" },
                new Eigenaar() { Id = 2, Email = "nonkelchameau@gmail.com", EigenaarNaam = "B-Parking" },
                new Eigenaar() { Id = 3, Email = "nonkelchameau@gmail.com", EigenaarNaam = "InterParking" }
                );

            context.Soorts.AddOrUpdate(x => x.Id,
                new Soort() { Id = 1, SoortNaam = "Elektrisch" },
                new Soort() { Id = 2, SoortNaam = "Standaard" },
                new Soort() { Id = 3, SoortNaam = "Met een beperking" },
                new Soort() { Id = 4, SoortNaam = "Abonnee" }
                );

            context.Locaties.AddOrUpdate(x => x.Id,
                new Locatie()
                {
                    Id = 1,
                    Straat = "Predikherenrei",
                    LandId = 1,
                    GemeenteId = 1
                },

                new Locatie()
                {
                    Id = 2,
                    Straat = "Spoorwegstraat",
                    LandId = 1,
                    GemeenteId = 1
                },

                new Locatie()
                {
                    Id = 3,
                    Straat = "'t Zand",
                    LandId = 1,
                    GemeenteId = 1
                },

                new Locatie()
                {
                    Id = 4,
                    Straat = "t'zuid",
                    LandId = 1,
                    GemeenteId = 2
                }

                );

            context.Parkings.AddOrUpdate(x => x.Id,
                new Parking()
                {
                    Id = 1,
                    EigenaarId = 1,
                    SoortId = 2,
                    LocatieId = 1,
                    Totaal = 5,
                    Bezet = 0,
                    ParkingNaam = "Langestraat"
                },

                new Parking()
                {
                    Id = 2,
                    EigenaarId = 2,
                    SoortId = 2,
                    LocatieId = 2,
                    Totaal = 1500,
                    Bezet = 0,
                    ParkingNaam = "Station"
                },

                new Parking()
                {
                    Id = 3,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 3,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "'t Zand"
                },
                             new Parking()
                             {
                                 Id = 3,
                                 EigenaarId = 3,
                                 SoortId = 2,
                                 LocatieId = 3,
                                 Totaal = 1434,
                                 Bezet = 0,
                                 ParkingNaam = "'t Zand"
                             }

                );

        }
    }
}
