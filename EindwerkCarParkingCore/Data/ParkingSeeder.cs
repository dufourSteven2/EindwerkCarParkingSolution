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
        
        public  void Seed()
        {
            _context.Database.EnsureCreated(); //test als database zeker bestaat
            

            if (!_context.Parkings.Any())
            {
                var Lands = new Land[]
                {
                    new Land() {LandNaam = "Belgie" },
                    new Land() {LandNaam = "Nederland" }
                };

                foreach(Land l in Lands)
                {
                    _context.Lands.Add(l);
                }

          //      var Totalen = new Totaal[]
          //      {
          //          new Totaal() {MaxParkings = 100, BezetteParkings= 50}
          //      };

          //      foreach (Totaal t in Totalen)
          //      {
          //          _context.Totaals.Add(t);
          //      }

          //      var plaatsen = new Gemeente[]
          //      {
          //            new Gemeente() {  GemeenteNaam = "Brugge" },
          //            new Gemeente() { GemeenteNaam = "Gent" },
          //            new Gemeente() {  GemeenteNaam = "Oostende" },
          //            new Gemeente() { GemeenteNaam = "Antwerpen" },
          //            new Gemeente() {  GemeenteNaam = "Brussel" },
          //            new Gemeente() {  GemeenteNaam = "Amsterdam" },
          //            new Gemeente() {  GemeenteNaam = "Eindhoven" }
          //      };

          //      foreach (Gemeente g in plaatsen)
          //      {
          //          _context.Gemeentes.Add(g);
          //      }

          //      var Eigenaars = new Eigenaar[]
          //      {
          //            new Eigenaar() {  Email = "nonkelchameau@gmail.com", EigenaarNaam = "Alfapark" },
          //            new Eigenaar() {  Email = "nonkelchameau@gmail.com", EigenaarNaam = "B-Parking" },
          //            new Eigenaar() {  Email = "nonkelchameau@gmail.com", EigenaarNaam = "InterParking" }
          //      };

          //      foreach (Eigenaar e in Eigenaars)
          //      {
          //          _context.Eigenaars.Add(e);
          //      }

          //      var Soorten = new Soort[]
          //      {

          //            new Soort() { SoortNaam = "Elektrisch" , TotaalId = 1},
          //            new Soort() { SoortNaam = "Standaard", TotaalId = 1 },
          //            new Soort() { SoortNaam = "Met een beperking", TotaalId = 1 },
          //            new Soort() { SoortNaam = "Abonnee", TotaalId = 1 }
          //      };

          //      foreach (Soort s in Soorten)
          //      {

          //          _context.Soorts.Add(s);
          //      }

          //      var Locaties = new Locatie[]
          //      {
          //                 new Locatie()
          //            {
          //                Straat = "Predikherenrei",
          //                Nr = "4A",
          //                LandId = 1,
          //                GemeenteId = 1
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Spoorwegstraat",
          //                Nr = "14",
          //                LandId = 1,
          //                GemeenteId = 1
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Hoefijzerlaan",
          //                Nr = "17",
          //                LandId = 1,
          //                GemeenteId = 1
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Franklin Rooseveltlaan",
          //                Nr = "3/A",
          //                LandId = 1,
          //                GemeenteId = 2
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Kouter",
          //                LandId = 1,
          //                GemeenteId = 2
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Sint-Pietersplein",
          //                Nr = "65",
          //                LandId = 1,
          //                GemeenteId = 2
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Mijnplein",
          //                LandId = 1,
          //                GemeenteId = 3
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Van Iseghemlaan",
          //                LandId = 1,
          //                GemeenteId = 3
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Ernest van Dijcklaai",
          //                Nr = "3",
          //                LandId = 1,
          //                GemeenteId = 4
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Oudevaartplaats",
          //                Nr = "2",
          //                LandId = 1,
          //                GemeenteId = 4
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Oosterdoksstraat",
          //                Nr = "150",
          //                LandId = 2,
          //                GemeenteId = 6
          //            },

          //            new Locatie()
          //            {
          //                Straat = "Emmasingel",
          //                Nr = "29",
          //                LandId = 2,
          //                GemeenteId = 7
          //            }
          //      };

          //      foreach (Locatie l in Locaties)
          //      {
          //          _context.Locaties.Add(l);
          //      }

          //      var parkingen = new Parking[]
          //      {
          //                  new Parking()
          //            {
          //                EigenaarId = 1,
          //                SoortId = 2,
          //                LocatieId = 1,
          //                Totaal = 5,
          //                Bezet = 0,
          //                ParkingNaam = "Langestraat"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 2,
          //                SoortId = 2,
          //                LocatieId = 2,
          //                Totaal = 1500,
          //                Bezet = 0,
          //                ParkingNaam = "Station"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 3,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "'t Zand"
          //            },
          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 4,
          //                Totaal = 2151,
          //                Bezet = 0,
          //                ParkingNaam = "Interparking Gent Zuid"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 5,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Parking Kouter"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 7,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Indigo Parking Mijnplein"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 8,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Indigo Park - Parking Cursaal 2"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 1,
          //                SoortId = 2,
          //                LocatieId = 6,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Parking Sint-Pietersplein"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 10,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Parking Arenberg"
          //            },

          //            new Parking()
          //            {
          //                EigenaarId = 3,
          //                SoortId = 2,
          //                LocatieId = 9,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Parking Grote Markt"
          //            },
          //            new Parking()
          //            {
          //                EigenaarId = 2,
          //                SoortId = 2,
          //                LocatieId = 11,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Parking Centrum Oosterdok"
          //            },
          //            new Parking()
          //            {
          //                EigenaarId = 2,
          //                SoortId = 2,
          //                LocatieId = 12,
          //                Totaal = 1434,
          //                Bezet = 0,
          //                ParkingNaam = "Q-Park Centrum de Admirant"
          //            }
          //};
          //      foreach (Parking p in parkingen)
          //      {
          //          _context.Parkings.Add(p);
          //      }

                _context.SaveChanges();
            }
        }
    }
}