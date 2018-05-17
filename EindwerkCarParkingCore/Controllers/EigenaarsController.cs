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
    [Route("api/Eigenaars")]
    public class EigenaarsController : Controller
    {
        private readonly EindwerkCarParkingCoreContext _context;

        public EigenaarsController(EindwerkCarParkingCoreContext context)
        {
            _context = context;
        }

        // GET: api/Eigenaars
        [HttpGet]
        public IEnumerable<Eigenaar> GetEigenaar()
        {
            return _context.Eigenaar;
        }

        // GET: api/Eigenaars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEigenaar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eigenaar = await _context.Eigenaar.SingleOrDefaultAsync(m => m.Id == id);

            if (eigenaar == null)
            {
                return NotFound();
            }

            return Ok(eigenaar);
        }

        // PUT: api/Eigenaars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEigenaar([FromRoute] int id, [FromBody] Eigenaar eigenaar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eigenaar.Id)
            {
                return BadRequest();
            }

            _context.Entry(eigenaar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EigenaarExists(id))
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

        // POST: api/Eigenaars
        [HttpPost]
        public async Task<IActionResult> PostEigenaar([FromBody] Eigenaar eigenaar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Eigenaar.Add(eigenaar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEigenaar", new { id = eigenaar.Id }, eigenaar);
        }

        // DELETE: api/Eigenaars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEigenaar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eigenaar = await _context.Eigenaar.SingleOrDefaultAsync(m => m.Id == id);
            if (eigenaar == null)
            {
                return NotFound();
            }

            _context.Eigenaar.Remove(eigenaar);
            await _context.SaveChangesAsync();

            return Ok(eigenaar);
        }

        private bool EigenaarExists(int id)
        {
            return _context.Eigenaar.Any(e => e.Id == id);
        }
    }
}