using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingLib;
using EindwerkCarParkingCore.Models;
using AutoMapper.QueryableExtensions;

namespace EindwerkCarParkingCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Locaties")]
    public class LocatiesController : Controller
    {
        private readonly EindwerkCarParkingContext _context;

        public LocatiesController(EindwerkCarParkingContext context)
        {
            _context = context;
        }

        // GET: api/Locaties
        [HttpGet]
        public IEnumerable<LocatieDTO> GetLocaties()
        {
            //return _context.Locaties;
            return _context.Locaties.ProjectTo<LocatieDTO>();
        }

        // GET: api/Locaties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocatie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locatie = await _context.Locaties.SingleOrDefaultAsync(m => m.Id == id);

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

            _context.Locaties.Add(locatie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocatieExists(locatie.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

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

            var locatie = await _context.Locaties.SingleOrDefaultAsync(m => m.Id == id);
            if (locatie == null)
            {
                return NotFound();
            }

            _context.Locaties.Remove(locatie);
            await _context.SaveChangesAsync();

            return Ok(locatie);
        }

        private bool LocatieExists(int id)
        {
            return _context.Locaties.Any(e => e.Id == id);
        }
    }
}