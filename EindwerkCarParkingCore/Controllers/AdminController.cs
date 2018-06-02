using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EindwerkCarParkingCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IParkingRepository _context;
        private readonly IMapper _mapper;
   
        public AdminController(IParkingRepository context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

       
        public IActionResult Overzicht()
        {
             var item = _context.GetAllParkings();
            var mappedItem = _mapper.Map<IEnumerable<ParkingsDetailDTO>>(item);
            return View(mappedItem);

        }


        // GET: MyAccount/Details/5
        public IActionResult Details(int id)
        {
            var parkings = _context.GetParkingById(id);
            var mappedItem = _mapper.Map<ParkingsDetailDTO>(parkings);
            return View(mappedItem);
        }
    }
}