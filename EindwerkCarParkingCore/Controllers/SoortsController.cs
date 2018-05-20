//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using EindwerkCarParkingCore.Data;
//using EindwerkCarParkingLib;
//using EindwerkCarParkingCore.Models;
//using AutoMapper.QueryableExtensions;

//namespace EindwerkCarParkingCore.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/Soorts")]
//    public class SoortsController : Controller
//    {
//        private readonly EindwerkCarParkingContext _context;

//        public SoortsController(EindwerkCarParkingContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Soorts
//        [HttpGet]
//        public IEnumerable<SoortDTO> GetSoorts()
//        {
//            //return _context.Soorts;
//            return _context.Soorts.ProjectTo<SoortDTO>();
//        }

//        // GET: api/Soorts/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetSoort([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var soort = await _context.Soorts.SingleOrDefaultAsync(m => m.Id == id);

//            if (soort == null)
//            {
//                return NotFound();
//            }

//            return Ok(soort);
//        }

//        // PUT: api/Soorts/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSoort([FromRoute] int id, [FromBody] Soort soort)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != soort.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(soort).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SoortExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Soorts
//        [HttpPost]
//        public async Task<IActionResult> PostSoort([FromBody] Soort soort)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Soorts.Add(soort);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (SoortExists(soort.Id))
//                {
//                    return new StatusCodeResult(StatusCodes.Status409Conflict);
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetSoort", new { id = soort.Id }, soort);
//        }

//        // DELETE: api/Soorts/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteSoort([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var soort = await _context.Soorts.SingleOrDefaultAsync(m => m.Id == id);
//            if (soort == null)
//            {
//                return NotFound();
//            }

//            _context.Soorts.Remove(soort);
//            await _context.SaveChangesAsync();

//            return Ok(soort);
//        }

//        private bool SoortExists(int id)
//        {
//            return _context.Soorts.Any(e => e.Id == id);
//        }
//    }
//}