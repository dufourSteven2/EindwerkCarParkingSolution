using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Models;
using EindwerkCarParkingLib;

namespace EindwerkCarParkingCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Parkings")]
    public class ParkingsController : Controller
    {
        private readonly EindwerkCarParkingCoreContext _context;

        public ParkingsController(EindwerkCarParkingCoreContext context)
        {
            _context = context;
        }

        // GET: api/Parkings
        [HttpGet]
        public IEnumerable<Parking> GetParking()
        {
            return _context.Parking;
        }

        // GET: api/Parkings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parking = await _context.Parking.SingleOrDefaultAsync(m => m.Id == id);

            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking);
        }

        // PUT: api/Parkings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParking([FromRoute] int id, [FromBody] Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parking.Id)
            {
                return BadRequest();
            }

            _context.Entry(parking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Parkings
        [HttpPost]
        public async Task<IActionResult> PostParking([FromBody] Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Parking.Add(parking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParking", new { id = parking.Id }, parking);
        }

        // DELETE: api/Parkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parking = await _context.Parking.SingleOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            _context.Parking.Remove(parking);
            await _context.SaveChangesAsync();

            return Ok(parking);
        }

        private bool ParkingExists(int id)
        {
            return _context.Parking.Any(e => e.Id == id);
        }
    }
}