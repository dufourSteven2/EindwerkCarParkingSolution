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
    [Route("api/Lands")]
    public class LandsController : Controller
    {
        private readonly EindwerkCarParkingCoreContext _context;

        public LandsController(EindwerkCarParkingCoreContext context)
        {
            _context = context;
        }

        // GET: api/Lands
        [HttpGet]
        public IEnumerable<Land> GetLand()
        {
            return _context.Land;
        }

        // GET: api/Lands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var land = await _context.Land.SingleOrDefaultAsync(m => m.Id == id);

            if (land == null)
            {
                return NotFound();
            }

            return Ok(land);
        }

        // PUT: api/Lands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLand([FromRoute] int id, [FromBody] Land land)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != land.Id)
            {
                return BadRequest();
            }

            _context.Entry(land).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandExists(id))
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

        // POST: api/Lands
        [HttpPost]
        public async Task<IActionResult> PostLand([FromBody] Land land)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Land.Add(land);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLand", new { id = land.Id }, land);
        }

        // DELETE: api/Lands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var land = await _context.Land.SingleOrDefaultAsync(m => m.Id == id);
            if (land == null)
            {
                return NotFound();
            }

            _context.Land.Remove(land);
            await _context.SaveChangesAsync();

            return Ok(land);
        }

        private bool LandExists(int id)
        {
            return _context.Land.Any(e => e.Id == id);
        }
    }
}