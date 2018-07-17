﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindwerkCarParkingLib;
using Microsoft.AspNetCore.Identity;

namespace EindwerkCarParkingCore.Data
{
    public class ParkingSeeder
    {
        private EindwerkCarParkingContext _context;
        private UserManager<ParkingUsers> _userManager;

        public ParkingSeeder(EindwerkCarParkingContext context, UserManager<ParkingUsers> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public void Seed()
        {
            _context.Database.EnsureCreated(); //test als database zeker bestaat

            if (_userManager.FindByNameAsync("Parkingbeheerbenny").Result == null)
            {
                ParkingUsers user = new ParkingUsers();
                user.UserName = "vanderschaeghe.benny@hotmail.com";
                user.Email = "vanderschaeghe.benny@hotmail.com";
                user.EmailConfirmed = true;
                user.EigenaarNaam = "ParkingBeheer";
                IdentityResult result = _userManager.CreateAsync
                (user, "@IVObrugge123").Result;

                //if (result.Succeeded)
                //{
                //    _userManager.AddToRoleAsync(user,
                //                        "NormalUser").Wait();
                //}
            }
            if (_userManager.FindByNameAsync("ParkingbeheerSteven").Result == null)
            {
                ParkingUsers user = new ParkingUsers();
                user.UserName = "nonkelchameau@gmail.com";
                user.Email = "nonkelchameau@gmail.com";
                user.EigenaarNaam = "ParkingBeheer";
                user.EmailConfirmed = true;

                IdentityResult result = _userManager.CreateAsync
                (user, "@IVObrugge123").Result;

                //if (result.Succeeded)
                //{
                //    _userManager.AddToRoleAsync(user,
                //                        "NormalUser").Wait();
                //}
            }
            if (_userManager.FindByNameAsync("Alfapark").Result == null)
            {
                ParkingUsers user = new ParkingUsers();
                user.UserName = "nonkelchameau2@gmail.com";
                user.Email = "nonkelchameau2@gmail.com";
                user.EigenaarNaam = "Alfapark";
                user.EmailConfirmed = true;

                IdentityResult result = _userManager.CreateAsync
                (user, "@IVObrugge123").Result;

                //if (result.Succeeded)
                //{
                //    _userManager.AddToRoleAsync(user,
                //                        "NormalUser").Wait();
                //}
            }
            if (_userManager.FindByNameAsync("B-Parking").Result == null)
            {
                ParkingUsers user = new ParkingUsers();
                user.UserName = "nonkelchameau3@gmail.com";
                user.Email = "nonkelchameau3@gmail.com";
                user.EigenaarNaam = "B-Parking";
                user.EmailConfirmed = true;

                IdentityResult result = _userManager.CreateAsync
                (user, "@IVObrugge123").Result;

                //if (result.Succeeded)
                //{
                //    _userManager.AddToRoleAsync(user,
                //                        "NormalUser").Wait();
                //}
            }
            if (_userManager.FindByNameAsync("InterParking").Result == null)
            {
                ParkingUsers user = new ParkingUsers();
                user.UserName = "nonkelchameau4@gmail.com";
                user.Email = "nonkelchameau4@gmail.com";
                user.EigenaarNaam = "InterParking";
                user.EmailConfirmed = true;

                IdentityResult result = _userManager.CreateAsync
                (user, "@IVObrugge123").Result;

                //if (result.Succeeded)
                //{
                //    //    _userManager.AddToRoleAsync(user,
                //    //                        "NormalUser").Wait();
                //    throw new InvalidOperationException("Failed to create Default user");
                //}
            }




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

            //    var Totalen = new Totaal[]
            //{
            //        new Totaal()  {Id=1,MaxParkings = 100, BezetteParkings= 50, SoortId=2},
            //         new Totaal()  {Id=2,MaxParkings = 200, BezetteParkings= 190, SoortId=3},
            //          new Totaal()  {Id=3,MaxParkings = 120, BezetteParkings= 10, SoortId=1},
            //           new Totaal()  {Id=4,MaxParkings = 8000, BezetteParkings= 6500, SoortId=4},
            //            new Totaal()  {Id=5,MaxParkings = 100, BezetteParkings= 75, SoortId=2},
            //             new Totaal()  {Id=6,MaxParkings = 10, BezetteParkings= 5, SoortId=1},
            //              new Totaal()  {Id=7,MaxParkings = 5, BezetteParkings= 2, SoortId=2}
            //};

            //    foreach (Totaal t in Totalen)
            //    {
            //        _context.Totaals.Add(t);
            //    }

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

                var Soorten = new Soort[]
                {

                      new Soort() {Id=1, SoortNaam = "Elektrisch"},
                      new Soort() {Id=2, SoortNaam = "Standaard"},
                      new Soort() {Id=3, SoortNaam = "Met een beperking"},
                      new Soort() {Id=4, SoortNaam = "Abonnee"}
                };

                foreach (Soort s in Soorten)
                {

                    _context.Soorts.Add(s);
                }

                var Locaties = new Locatie[]
                {
                           new Locatie()
                      {
                       Id=1,
                          Straat = "Predikherenrei",
                          Nr = "4A",
                          GemeenteId = 1
                      },

                      new Locatie()
                      {Id=2,
                          Straat = "Spoorwegstraat",
                          Nr = "14",
                          GemeenteId = 1
                      },

                      new Locatie()
                      {Id=3,
                          Straat = "Hoefijzerlaan",
                          Nr = "17",
                          GemeenteId = 1
                      },

                      new Locatie()
                      {Id=4,
                          Straat = "Franklin Rooseveltlaan",
                          Nr = "3/A",
                          GemeenteId = 2
                      },

                      new Locatie()
                      {Id=5,
                          Straat = "Kouter",
                          GemeenteId = 2
                      },

                      new Locatie()
                      {Id=6,
                          Straat = "Sint-Pietersplein",
                          Nr = "65",
                          GemeenteId = 2
                      },

                      new Locatie()
                      {Id=7,
                          Straat = "Mijnplein",
                          GemeenteId = 3
                      },

                      new Locatie()
                      {Id=8,
                          Straat = "Van Iseghemlaan",
                          GemeenteId = 3
                      },

                      new Locatie()
                      {Id=9,
                          Straat = "Ernest van Dijcklaai",
                          Nr = "3",
                          GemeenteId = 4
                      },

                      new Locatie()
                      {Id=10,
                          Straat = "Oudevaartplaats",
                          Nr = "2",
                          GemeenteId = 4
                      },

                      new Locatie()
                      {Id=11,
                          Straat = "Oosterdoksstraat",
                          Nr = "150",
                          GemeenteId = 6
                      },

                      new Locatie()
                      {Id=12,
                          Straat = "Emmasingel",
                          Nr = "29",
                          GemeenteId = 7
                      }
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
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 2,
                          LocatieId = 1,
                          Totaal = 100,
                          Bezet = 0,
                          ParkingNaam = "Langestraat",
                          PublicatieToelating = true
                      },
                      new Parking()
                      {
                          Id=2,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 1,
                          LocatieId = 1,
                          Totaal = 10,
                          Bezet = 10,
                          ParkingNaam = "Langestraat",
                          PublicatieToelating = true
                      },
                      new Parking()
                      {
                          Id=3,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 3,
                          LocatieId = 1,
                          Totaal = 10,
                          Bezet = 8,
                          ParkingNaam = "Langestraat",
                          PublicatieToelating = true
                      },

                      new Parking()
                      {
                          Id =4,
                          ParkingUsersName = "nonkelchameau3@gmail.com",
                          SoortId = 1,
                          LocatieId = 2,
                          Totaal = 20,
                          Bezet = 0,
                          ParkingNaam = "Station",
                          PublicatieToelating = true,
                 
                      },
                      new Parking()
                      {
                          Id =5,
                          ParkingUsersName = "nonkelchameau3@gmail.com",
                          SoortId = 2,
                          LocatieId = 2,
                          Totaal = 100,
                          Bezet = 0,
                          ParkingNaam = "Station",
                          PublicatieToelating = true,

                      },

                      new Parking()
                      {  Id=6,
                          ParkingUsersName = "nonkelchameau4@gmail.com",
                          SoortId = 2,
                          LocatieId = 3,
                          Totaal = 100,
                          Bezet = 100,
                          ParkingNaam = "'t Zand",
                          PublicatieToelating = true
                      },
                      new Parking()
                      {
                          Id =7,
                          ParkingUsersName = "nonkelchameau4@gmail.com",
                          SoortId = 1,
                          LocatieId = 3,
                          Totaal = 100,
                          Bezet = 0,
                          ParkingNaam = "'t Zand",
                          PublicatieToelating = true
                      },
                      new Parking()
                      {
                          Id =8,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 2,
                          LocatieId = 4,
                          Totaal = 15,
                          Bezet = 0,
                          ParkingNaam = "Interparking Gent Zuid",
                          PublicatieToelating = false
                      },
                      new Parking()
                      {
                          Id =9,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 1,
                          LocatieId = 4,
                          Totaal = 15,
                          Bezet = 13,
                          ParkingNaam = "Interparking Gent Zuid",
                          PublicatieToelating = false
                      },

                      new Parking()
                      {
                          Id=10,
                          ParkingUsersName = "nonkelchameau4@gmail.com",
                          SoortId = 2,
                          LocatieId = 5,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Kouter",
                          PublicatieToelating = true
                      },
                      new Parking()
                      {
                          Id=18,
                          ParkingUsersName = "nonkelchameau4@gmail.com",
                          SoortId = 1,
                          LocatieId = 5,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Kouter",
                          PublicatieToelating = true
                      },

                      new Parking()
                      {
                          Id =11,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 2,
                          LocatieId = 7,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Indigo Parking Mijnplein",
                          PublicatieToelating = true
                      },

                      new Parking()
                      {
                          Id =12,
                          ParkingUsersName = "nonkelchameau3@gmail.com",
                          SoortId = 2,
                          LocatieId = 8,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Indigo Park - Parking Cursaal 2",
                          PublicatieToelating = true
                      },

                      new Parking()
                      {
                          Id =13,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 2,
                          LocatieId = 6,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Sint-Pietersplein",
                          PublicatieToelating = true
                      },

                      new Parking()
                      {   Id=14,
                          ParkingUsersName = "nonkelchameau3@gmail.com",
                          SoortId = 2,
                          LocatieId = 10,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Arenberg",
                          PublicatieToelating = true
                      },

                      new Parking()
                      {
                          Id =15,
                          ParkingUsersName = "nonkelchameau4@gmail.com",
                          SoortId = 2,
                          LocatieId = 9,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Grote Markt",
                          PublicatieToelating = false
                      },
                      new Parking()
                      {
                          Id =16,
                          ParkingUsersName = "nonkelchameau2@gmail.com",
                          SoortId = 2,
                          LocatieId = 11,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Parking Centrum Oosterdok",
                          PublicatieToelating = true
                      },
                      new Parking()
                      {
                          Id =17,
                          ParkingUsersName = "nonkelchameau3@gmail.com",
                          SoortId = 2,
                          LocatieId = 12,
                          Totaal = 1434,
                          Bezet = 0,
                          ParkingNaam = "Q-Park Centrum de Admirant",
                          PublicatieToelating = true
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


