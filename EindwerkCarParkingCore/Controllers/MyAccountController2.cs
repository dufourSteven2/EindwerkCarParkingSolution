using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EindwerkCarParkingCore.Controllers
{
    [Authorize]
    public class MyAccountController2 : Controller
    {
        private readonly lMailService _mailservice;
        private readonly IParkingRepository _context;
        private readonly IMapper _mapper;
        public MyAccountController2(lMailService mailservice, IParkingRepository context, IMapper mapper)
        {
            _mailservice = mailservice;
            _context = context;
            _mapper = mapper;
        }

 
        public IActionResult Overzicht()
        {
            var user = User.Identity.Name;
            var item = _context.GetAllParkingsByUser(user);
            var mappedItem = _mapper.Map<IEnumerable<ParkingsDetailDTO>>(item);
            return View(mappedItem);
           
        }
    }
}