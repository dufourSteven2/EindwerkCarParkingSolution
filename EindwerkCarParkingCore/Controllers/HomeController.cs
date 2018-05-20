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

namespace EindwerkCarParkingCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly lMailService _mailservice;
        private readonly EindwerkCarParkingContext _context;
        private readonly IMapper _mapper;
        public HomeController(lMailService mailservice, EindwerkCarParkingContext context, IMapper mapper)
        {
            _mailservice = mailservice;
            _context = context;
            /////
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

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

        public IActionResult SearchParking()
        {
            return View();
        }
        // Test Mapper met actionresultdtotester bron https://www.youtube.com/watch?v=5WP36DIwdlI       
        public IActionResult DtoTester()
        {
            var item = _context.Parkings;
            var mappedItem = _mapper.Map<List<ParkingsDTO>>(item);

            return View(mappedItem);
            
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Parkings()
        {
            //var item = _context.Parkings;
            var results = _context.Parkings.OrderBy(p => p.Locatie).ToList();
            return View(results);
        }
    }
}
