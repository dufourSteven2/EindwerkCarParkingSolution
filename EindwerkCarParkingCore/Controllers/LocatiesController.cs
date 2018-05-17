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
    [Route("api/Locaties")]
    public class LocatiesController : Controller
    {
        private readonly EindwerkCarParkingCoreContext _context;

        public LocatiesController(EindwerkCarParkingCoreContext context)
        {
            _context = context;
        }

        // GET: api/Locaties
        [HttpGet]
        public IEnumerable<Locatie> GetLocatie()
        {
            return _context.Locatie;
        }

        // GET: api/Locaties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocatie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locatie = await _context.Locatie.SingleOrDefaultAsync(m => m.Id == id);

            if (locatie == null)
            {
                return NotFound();
            }

            return Ok(locatie);
        }

        // PUT: api/Locaties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocatie([FromRoute] int id, [FromBody] Locatie locatie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locatie.Id)
            {
                return BadRequest();
            }

            _context.Entry(locatie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocatieExists(id))
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

        // POST: api/Locaties
        [HttpPost]
        public async Task<IActionResult> PostLocatie([FromBody] Locatie locatie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Locatie.Add(locatie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocatie", new { id = locatie.Id }, locatie);
        }

        // DELETE: api/Locaties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocatie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locatie = await _context.Locatie.SingleOrDefaultAsync(m => m.Id == id);
            if (locatie == null)
            {
                return NotFound();
            }

            _context.Locatie.Remove(locatie);
            await _context.SaveChangesAsync();

            return Ok(locatie);
        }

        private bool LocatieExists(int id)
        {
            return _context.Locatie.Any(e => e.Id == id);
        }
    }
}