using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingLib;

namespace EindwerkCarParkingCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Landen")]
    public class LandenController : Controller
    {
        private readonly EindwerkCarParkingContext _context;

        public LandenController(EindwerkCarParkingContext context)
        {
            _context = context;
        }

        // GET: api/Landen
        [HttpGet]
        public IEnumerable<Land> GetLands()
        {
            return _context.Lands;
        }

        // GET: api/Landen/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var land = await _context.Lands.SingleOrDefaultAsync(m => m.Id == id);

            if (land == null)
            {
                return NotFound();
            }

            return Ok(land);
        }

        // PUT: api/Landen/5
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

        // POST: api/Landen
        [HttpPost]
        public async Task<IActionResult> PostLand([FromBody] Land land)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lands.Add(land);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LandExists(land.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLand", new { id = land.Id }, land);
        }

        // DELETE: api/Landen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var land = await _context.Lands.SingleOrDefaultAsync(m => m.Id == id);
            if (land == null)
            {
                return NotFound();
            }

            _context.Lands.Remove(land);
            await _context.SaveChangesAsync();

            return Ok(land);
        }

        private bool LandExists(int id)
        {
            return _context.Lands.Any(e => e.Id == id);
        }
    }
}