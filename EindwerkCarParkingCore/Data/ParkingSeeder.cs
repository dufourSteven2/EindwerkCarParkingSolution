using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindwerkCarParkingLib;

namespace EindwerkCarParkingCore.Data
{
    public class ParkingSeeder
    {
        private EindwerkCarParkingContext _context;

        public ParkingSeeder(EindwerkCarParkingContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated(); //test als database zeker bestaat


            if (!_context.Parkings.Any())
            {
                var Lands = new Land[]
                {
                    new Land() {Id= 1, LandNaam = "Belgie" },
                    new Land() {Id= 2, LandNaam = "Nederland" }
                };

                foreach (Land l in Lands)
                {
                    _context.Lands.Add(l);
                }

                var Totalen = new Totaal[]
            {
                    new Totaal() {MaxParkings = 100, BezetteParkings= 50}
            };

                foreach (Totaal t in Totalen)
                {
                    _context.Totaals.Add(t);
                }

                var plaatsen = new Gemeente[]
                {
                      new Gemeente() {Id= 1,  GemeenteNaam = "Brugge" ,LandId=1},
                      new Gemeente() {Id= 2, GemeenteNaam = "Gent", LandId=1 },
                      new Gemeente() {Id= 3,  GemeenteNaam = "Oostende" ,LandId =1},
                      new Gemeente() {Id= 4, GemeenteNaam = "Antwerpen" ,LandId =1 },
                      new Gemeente() {Id= 5,  GemeenteNaam = "Brussel" ,LandId =1},
                      new Gemeente() {Id= 6,  GemeenteNaam = "Amsterdam" ,LandId =2 },
                      new Gemeente() {Id= 7,  GemeenteNaam = "Eindhoven" ,LandId =2}
                };

                foreach (Gemeente g in plaatsen)
                {
                    _context.Gemeentes.Add(g);
                }

                var Eigenaars = new Eigenaar[]
                {
                      new Eigenaar() {Id=1,  Email = "nonkelchameau@gmail.com", EigenaarNaam = "Alfapark" },
                      new Eigenaar() {Id=2,  Email = "nonkelchameau@gmail.com", EigenaarNaam = "B-Parking" },
                      new Eigenaar() {Id=3, Email = "nonkelchameau@gmail.com", EigenaarNaam = "InterParking" }
                };

                foreach (Eigenaar e in Eigenaars)
                {
                    _context.Eigenaars.Add(e);
                }

                var Soorten = new Soort[]
                {

                      new Soort() { SoortNaam = "Elektrisch" , TotaalId = 1},
                      new Soort() { SoortNaam = "Standaard", TotaalId = 1 },
                      new Soort() { SoortNaam = "Met een beperking", TotaalId = 1 },
                      new Soort() { SoortNaam = "Abonnee", TotaalId = 1 }
                };

                foreach (Soort s in Soorten)
                {

                    _context.Soorts.Add(s);
                }

                var Locaties = new Locatie[]
                {
                           new Locatie()
                      {
                            
                          Straat = "Predikherenrei",
                          Nr = "4A",
                          GemeenteId = 1
                      },

                      new Locatie()
                      {
                          Straat = "Spoorwegstraat",
                          Nr = "14",
                          GemeenteId = 1
                      },

                      new Locatie()
                      {
                          Straat = "Hoefijzerlaan",
                          Nr = "17",
                          GemeenteId = 1
                      },

                      new Locatie()
                      {
                          Straat = "Franklin Rooseveltlaan",
                          Nr = "3/A",
                          GemeenteId = 2
                      },

                      new Locatie()
                      {
                          Straat = "Kouter",
                          GemeenteId = 2
                      },

                      new Locatie()
                      {
                          Straat = "Sint-Pietersplein",
                          Nr = "65",
                          GemeenteId = 2
                      },

                      //new Locatie()
                      //{Id=7,
                      //    Straat = "Mijnplein",
                      //    GemeenteId = 3
                      //},

                      //new Locatie()
                      //{Id=8,
                      //    Straat = "Van Iseghemlaan",
                      //    GemeenteId = 3
                      //},

                      //new Locatie()
                      //{Id=9,
                      //    Straat = "Ernest van Dijcklaai",
                      //    Nr = "3",
                      //    GemeenteId = 4
                      //},

                      //new Locatie()
                      //{Id=10,
                      //    Straat = "Oudevaartplaats",
                      //    Nr = "2",
                      //    GemeenteId = 4
                      //},

                      //new Locatie()
                      //{Id=11,
                      //    Straat = "Oosterdoksstraat",
                      //    Nr = "150",
                      //    GemeenteId = 6
                      //},

                      //new Locatie()
                      //{Id=12,
                      //    Straat = "Emmasingel",
                      //    Nr = "29",
                      //    GemeenteId = 7
                      //}
                };

                foreach (Locatie l in Locaties)
                {
                    _context.Locaties.Add(l);
                }

                var parkingen = new Parking[]
                {
                            new Parking()
                      {
                                Id=1,
                          EigenaarId = 1,
                          SoortId = 2,
                          LocatieId = 1,
                          Totaal = 5,
                          Bezet = 0,
                          ParkingNaam = "Langestraat"
                      },

                      new Parking()
                      {  Id=2,
                          EigenaarId = 2,
                          SoortId = 2,
                          LocatieId = 2,
                          Totaal = 1500,
                          Bezet = 0,
                          ParkingNaam = "Station"
                      },

                      new Parking()
                      {  Id=3,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 3,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "'t Zand"
                      },
                      new Parking()
                      {  Id=4,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 4,
                          Totaal = 2151,
                          Bezet = 0,
                          ParkingNaam = "Interparking Gent Zuid"
                      },

                      new Parking()
                      {
                            Id=5,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 5,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Kouter"
                      },

                      new Parking()
                      {  Id=6,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 7,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Indigo Parking Mijnplein"
                      },

                      new Parking()
                      {  Id=7,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 8,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Indigo Park - Parking Cursaal 2"
                      },

                      new Parking()
                      {  Id=8,
                          EigenaarId = 1,
                          SoortId = 2,
                          LocatieId = 6,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Sint-Pietersplein"
                      },

                      new Parking()
                      {  Id=9,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 10,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Arenberg"
                      },

                      new Parking()
                      {  Id=10,
                          EigenaarId = 3,
                          SoortId = 2,
                          LocatieId = 9,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Grote Markt"
                      },
                      new Parking()
                      {  Id=11,
                          EigenaarId = 2,
                          SoortId = 2,
                          LocatieId = 11,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Centrum Oosterdok"
                      },
                      new Parking()
                      {  Id=12,
                          EigenaarId = 2,
                          SoortId = 2,
                          LocatieId = 12,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Q-Park Centrum de Admirant"
                      }
          };
                foreach (Parking p in parkingen)
                {
                    _context.Parkings.Add(p);
                }

                _context.SaveChanges();
            }
        }
    }
}