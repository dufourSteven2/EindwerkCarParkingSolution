using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingLib;

namespace EindwerkCarParkingCore.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly EindwerkCarParkingContext _context;

        public MyAccountController(EindwerkCarParkingContext context)
        {
            _context = context;
        }

        // GET: MyAccount
        public async Task<IActionResult> Index()
        {
            var eindwerkCarParkingContext = _context.Parkings.Include(p => p.Locatie);
            return View(await eindwerkCarParkingContext.ToListAsync());
        }

        // GET: MyAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings
                .Include(p => p.Locatie)
              //  .Include(p => p.Soort)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // GET: MyAccount/Create
        public IActionResult Create()
        {
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "Id", "Straat");
           // ViewData["SoortId"] = new SelectList(_context.Soorts, "Id", "SoortNaam");
            return View();
        }

        // POST: MyAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParkingNaam,Totaal,Bezet,PublicatieToelating,ParkingUsersId,SoortId,LocatieId")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "Id", "Straat", parking.LocatieId);
         //   ViewData["SoortId"] = new SelectList(_context.Soorts, "Id", "SoortNaam", parking.SoortId);
            return View(parking);
        }

        // GET: MyAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings.SingleOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "Id", "Straat", parking.LocatieId);
         //   ViewData["SoortId"] = new SelectList(_context.Soorts, "Id", "SoortNaam", parking.SoortId);
            return View(parking);
        }

        // POST: MyAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParkingNaam,Totaal,Bezet,PublicatieToelating,ParkingUsersId,SoortId,LocatieId")] Parking parking)
        {
            if (id != parking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingExists(parking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "Id", "Straat", parking.LocatieId);
         //   ViewData["SoortId"] = new SelectList(_context.Soorts, "Id", "SoortNaam", parking.SoortId);
            return View(parking);
        }

        // GET: MyAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings
                .Include(p => p.Locatie)
            //    .Include(p => p.Soort)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // POST: MyAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parking = await _context.Parkings.SingleOrDefaultAsync(m => m.Id == id);
            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }
    }
}
