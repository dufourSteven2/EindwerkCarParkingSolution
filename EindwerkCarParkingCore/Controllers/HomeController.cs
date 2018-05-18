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

namespace EindwerkCarParkingCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly lMailService _mailservice;
        private readonly EindwerkCarParkingContext _context;
        public HomeController(lMailService mailservice, EindwerkCarParkingContext context)
        {
            _mailservice = mailservice;
            _context = context;
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Parkings()
        {
            var results = _context.Parkings.OrderBy(p => p.Locatie).ToList();
            return View(results);
        }
    }
}
