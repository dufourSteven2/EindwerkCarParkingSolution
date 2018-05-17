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
    [Route("api/Gemeentes")]
    public class GemeentesController : Controller
    {
        private readonly EindwerkCarParkingCoreContext _context;

        public GemeentesController(EindwerkCarParkingCoreContext context)
        {
            _context = context;
        }

        // GET: api/Gemeentes
        [HttpGet]
        public IEnumerable<Gemeente> GetGemeente()
        {
            return _context.Gemeente;
        }

        // GET: api/Gemeentes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGemeente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gemeente = await _context.Gemeente.SingleOrDefaultAsync(m => m.Id == id);

            if (gemeente == null)
            {
                return NotFound();
            }

            return Ok(gemeente);
        }

        // PUT: api/Gemeentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGemeente([FromRoute] int id, [FromBody] Gemeente gemeente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gemeente.Id)
            {
                return BadRequest();
            }

            _context.Entry(gemeente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GemeenteExists(id))
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

        // POST: api/Gemeentes
        [HttpPost]
        public async Task<IActionResult> PostGemeente([FromBody] Gemeente gemeente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Gemeente.Add(gemeente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGemeente", new { id = gemeente.Id }, gemeente);
        }

        // DELETE: api/Gemeentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGemeente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gemeente = await _context.Gemeente.SingleOrDefaultAsync(m => m.Id == id);
            if (gemeente == null)
            {
                return NotFound();
            }

            _context.Gemeente.Remove(gemeente);
            await _context.SaveChangesAsync();

            return Ok(gemeente);
        }

        private bool GemeenteExists(int id)
        {
            return _context.Gemeente.Any(e => e.Id == id);
        }
    }
}