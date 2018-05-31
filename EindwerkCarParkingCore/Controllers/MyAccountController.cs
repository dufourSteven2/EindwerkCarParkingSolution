using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingCore.Models;
using AutoMapper;
using EindwerkCarParkingCore.Services;
using Microsoft.AspNetCore.Authorization;

namespace EindwerkCarParkingCore.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        private readonly IParkingRepository _context;
        private readonly IMapper _mapper;

        public MyAccountController(IParkingRepository context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: MyAccount
        public IActionResult Overzicht()
        {
            var user = User.Identity.Name;
            var item = _context.GetAllParkingsByUser(user);
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

        //// GET: MyAccount/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MyAccount/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ParkingNaam,LocatieStraat,LocatieNummer,GemeenteGemeenteNaam,LandLandNaam,BedrijfsNaam")] ParkingsDetailDTO parkingsDetailDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(parkingsDetailDTO);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Overzicht));
        //    }
        //    return View(parkingsDetailDTO);
        //}

        //    // GET: MyAccount/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var parkingsDetailDTO = await _context.ParkingsDetailDTO.SingleOrDefaultAsync(m => m.Id == id);
        //        if (parkingsDetailDTO == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(parkingsDetailDTO);
        //    }

        //    // POST: MyAccount/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,ParkingNaam,LocatieStraat,LocatieNummer,GemeenteGemeenteNaam,LandLandNaam,BedrijfsNaam")] ParkingsDetailDTO parkingsDetailDTO)
        //    {
        //        if (id != parkingsDetailDTO.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(parkingsDetailDTO);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!ParkingsDetailDTOExists(parkingsDetailDTO.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Overzicht));
        //        }
        //        return View(parkingsDetailDTO);
        //    }

        //    // GET: MyAccount/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var parkingsDetailDTO = await _context.ParkingsDetailDTO
        //            .SingleOrDefaultAsync(m => m.Id == id);
        //        if (parkingsDetailDTO == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(parkingsDetailDTO);
        //    }

        //    // POST: MyAccount/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var parkingsDetailDTO = await _context.ParkingsDetailDTO.SingleOrDefaultAsync(m => m.Id == id);
        //        _context.ParkingsDetailDTO.Remove(parkingsDetailDTO);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Overzicht));
        //    }

        //    private bool ParkingsDetailDTOExists(int id)
        //    {
        //        return _context.ParkingsDetailDTO.Any(e => e.Id == id);
        //    }
        //}
    }
}
