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
    [Route("api/Totaals")]
    public class TotaalsController : Controller
    {
        private readonly EindwerkCarParkingCoreContext _context;

        public TotaalsController(EindwerkCarParkingCoreContext context)
        {
            _context = context;
        }

        // GET: api/Totaals
        [HttpGet]
        public IEnumerable<Totaal> GetTotaal()
        {
            return _context.Totaal;
        }

        // GET: api/Totaals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTotaal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var totaal = await _context.Totaal.SingleOrDefaultAsync(m => m.Id == id);

            if (totaal == null)
            {
                return NotFound();
            }

            return Ok(totaal);
        }

        // PUT: api/Totaals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTotaal([FromRoute] int id, [FromBody] Totaal totaal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != totaal.Id)
            {
                return BadRequest();
            }

            _context.Entry(totaal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotaalExists(id))
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

        // POST: api/Totaals
        [HttpPost]
        public async Task<IActionResult> PostTotaal([FromBody] Totaal totaal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Totaal.Add(totaal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTotaal", new { id = totaal.Id }, totaal);
        }

        // DELETE: api/Totaals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTotaal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var totaal = await _context.Totaal.SingleOrDefaultAsync(m => m.Id == id);
            if (totaal == null)
            {
                return NotFound();
            }

            _context.Totaal.Remove(totaal);
            await _context.SaveChangesAsync();

            return Ok(totaal);
        }

        private bool TotaalExists(int id)
        {
            return _context.Totaal.Any(e => e.Id == id);
        }
    }
}