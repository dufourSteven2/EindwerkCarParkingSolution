namespace EindwerkCarParking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EindwerkCarParkingLib;

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
            //  to avoid creating duplicate seed data.
            
            context.Totaals.AddOrUpdate(x => x.Id,
                new Totaal() { Id = 1, MaxParkings = 100, BezetteParkings = 50 }

                );


            context.Lands.AddOrUpdate(x => x.Id,
             new Land() { Id = 1, LandNaam = "Belgie" },
             new Land() { Id = 2, LandNaam = "Nederland" },
             new Land() { Id = 3, LandNaam = "Frankrijk" }
             );

            context.Gemeentes.AddOrUpdate(x => x.Id,
                new Gemeente() { Id = 1, GemeenteNaam = "Brugge" },
                new Gemeente() { Id = 2, GemeenteNaam = "Gent" },
                new Gemeente() { Id = 3, GemeenteNaam = "Oostende" },
                 new Gemeente() { Id = 4, GemeenteNaam = "Antwerpen" },
                  new Gemeente() { Id = 5, GemeenteNaam = "Brussel" },
                   new Gemeente() { Id = 6, GemeenteNaam = "Amsterdam" },
                    new Gemeente() { Id = 7, GemeenteNaam = "Eindhoven" }
                );

            context.Eigenaars.AddOrUpdate(x => x.Id,
                new Eigenaar() { Id = 1, Email = "nonkelchameau@gmail.com", EigenaarNaam = "Alfapark" },
                new Eigenaar() { Id = 2, Email = "nonkelchameau@gmail.com", EigenaarNaam = "B-Parking" },
                new Eigenaar() { Id = 3, Email = "nonkelchameau@gmail.com", EigenaarNaam = "InterParking" }
                );

            context.Soorts.AddOrUpdate(x => x.Id,
                new Soort() { Id = 1, SoortNaam = "Elektrisch" , TotaalId = 1},
                new Soort() { Id = 2, SoortNaam = "Standaard", TotaalId = 1 },
                new Soort() { Id = 3, SoortNaam = "Met een beperking", TotaalId = 1 },
                new Soort() { Id = 4, SoortNaam = "Abonnee", TotaalId = 1 }
                );

            

            context.Locaties.AddOrUpdate(x => x.Id,
                new Locatie()
                {
                    Id = 1,
                    Straat = "Predikherenrei",
                    Nr = "4A",
                    LandId = 1,
                    GemeenteId = 1
                },

                new Locatie()
                {
                    Id = 2,
                    Straat = "Spoorwegstraat",
                    Nr = "14",
                    LandId = 1,
                    GemeenteId = 1
                },

                new Locatie()
                {
                    Id = 3,
                    Straat = "Hoefijzerlaan",
                    Nr = "17",
                    LandId = 1,
                    GemeenteId = 1
                },

                new Locatie()
                {
                    Id = 4,
                    Straat = "Franklin Rooseveltlaan",
                    Nr = "3/A",
                    LandId = 1,
                    GemeenteId = 2
                },

                new Locatie()
                {
                    Id = 5,
                    Straat = "Kouter",
                    LandId = 1,
                    GemeenteId = 2
                },

                new Locatie()
                {
                    Id = 6,
                    Straat = "Sint-Pietersplein",
                    Nr = "65",
                    LandId = 1,
                    GemeenteId = 2
                },

                new Locatie()
                {
                    Id = 7,
                    Straat = "Mijnplein",
                    LandId = 1,
                    GemeenteId = 3
                },

                new Locatie()
                {
                    Id = 8,
                    Straat = "Van Iseghemlaan",
                    LandId = 1,
                    GemeenteId = 3
                },

                new Locatie()
                {
                    Id = 9,
                    Straat = "Ernest van Dijcklaai",
                    Nr = "3",
                    LandId = 1,
                    GemeenteId = 4
                },

                new Locatie()
                {
                    Id = 10,
                    Straat = "Oudevaartplaats",
                    Nr = "2",
                    LandId = 1,
                    GemeenteId = 4
                },

                new Locatie()
                {
                    Id = 11,
                    Straat = "Oosterdoksstraat",
                    Nr = "150",
                    LandId = 2,
                    GemeenteId = 6
                },

                new Locatie()
                {
                    Id = 12,
                    Straat = "Emmasingel",
                    Nr = "29",
                    LandId = 2,
                    GemeenteId = 7
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
                    Id = 4,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 4,
                    Totaal = 2151,
                    Bezet = 0,
                    ParkingNaam = "Interparking Gent Zuid"
                },

                new Parking()
                {
                    Id = 5,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 5,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Parking Kouter"
                },

                new Parking()
                {
                    Id = 6,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 7,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Indigo Parking Mijnplein"
                },

                new Parking()
                {
                    Id = 7,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 8,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Indigo Park - Parking Cursaal 2"
                },

                new Parking()
                {
                    Id = 8,
                    EigenaarId = 1,
                    SoortId = 2,
                    LocatieId = 6,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Parking Sint-Pietersplein"
                },

                new Parking()
                {
                    Id = 9,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 10,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Parking Arenberg"
                },

                new Parking()
                {
                    Id = 10,
                    EigenaarId = 3,
                    SoortId = 2,
                    LocatieId = 9,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Parking Grote Markt"
                },
                new Parking()
                {
                    Id = 11,
                    EigenaarId = 2,
                    SoortId = 2,
                    LocatieId = 11,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Parking Centrum Oosterdok"
                },
                new Parking()
                {
                    Id = 12,
                    EigenaarId = 2,
                    SoortId = 2,
                    LocatieId = 12,
                    Totaal = 1434,
                    Bezet = 0,
                    ParkingNaam = "Q-Park Centrum de Admirant"
                }

                );

        }

    }
}
