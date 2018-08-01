using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingCore.ViewModels;
using EindwerkCarParkingCore.Services;
using EindwerkCarParkingCore.Data;
using AutoMapper;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace EindwerkCarParkingCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly lMailService _mailservice;
        private readonly IParkingRepository _context;
        private readonly IMapper _mapper;
        public HomeController(lMailService mailservice, IParkingRepository context, IMapper mapper)
        {
            _mailservice = mailservice;
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var item = _context.GetLast5AddedParkings();
           var mappedItem = _mapper.Map<IEnumerable<ParkingsDetailDTO>>(item);
            return View(mappedItem);
        }
        //Hieronder poging VUE.js
        public ActionResult IndexVue()
        {
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        [HttpGet("TestAngular")]
        public IActionResult TestAngular()
        {
                return View();
        }
        [HttpGet("ParkinLijst")] // deze toegevoegd om parkingljst te maken
        public IActionResult ParkingLijst()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {

                _mailservice.SendMessage("MailSettings:ToAddress", model.Subject, model.Message);
                ViewBag.UserMessage = "Message Sent";
                ModelState.Clear();

            }
            return View();
        }

        //toevoegen parking voor gerigistreerde accounts
        [Authorize]
        public IActionResult AddParking()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Overzicht", "MyAccount");
            }
            return View();
        }

        // Test Mapper met actionresultdtotester bron https://www.youtube.com/watch?v=5WP36DIwdlI       
        public IActionResult DtoTester()
        {
            var item = _context.GetAllParkings();
            var mappedItem = _mapper.Map<IEnumerable<ParkingsDetailDTO>>(item);

            return View(mappedItem);
            
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Parkings()
        {
            IEnumerable<LandDTO>landenlijst = new List<LandDTO>();
            landenlijst = _context.getLanden();

            var item = _context.GetAllParkings();
            var mappedItem = _mapper.Map<IEnumerable<ParkingsDetailDTO>>(item);
            ViewBag.ListofLanden = landenlijst;
            return View(mappedItem);

        }

        //public IActionResult Totalen()
        //{
        //    IEnumerable<TotaalDTO> totalen = new List<TotaalDTO>();
        //    totalen = _context.GetTotalen();
        //    return View(totalen);
        //}

        public JsonResult GetCountries() {
            var landen = new List<LandDTO>();
            foreach (LandDTO l in landen)
            {
                landen.Add(l);
            }
            return Json(landen);
        }

        [HttpPost]
        public JsonResult GetSteden(string country)
        {
            var gemeenten = new List<GemeenteDTO>();
            if (!string.IsNullOrWhiteSpace(country))
            {
                foreach(GemeenteDTO g in gemeenten)
                {
                    gemeenten.Add(g);
                }
            }
            return Json(gemeenten);
        }
    }
}
