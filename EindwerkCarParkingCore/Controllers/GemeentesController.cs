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
//    [Route("api/Gemeentes")]
//    public class GemeentesController : Controller
//    {
//        private readonly EindwerkCarParkingContext _context;

//        public GemeentesController(EindwerkCarParkingContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Gemeentes
//        [HttpGet]
//        public IEnumerable<GemeenteDTO> GetGemeentes()
//        {
//            //return _context.Gemeentes;
//            return _context.Gemeentes.ProjectTo<GemeenteDTO>();
//        }

//        // GET: api/Gemeentes/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetGemeente([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var gemeente = await _context.Gemeentes.SingleOrDefaultAsync(m => m.Id == id);

//            if (gemeente == null)
//            {
//                return NotFound();
//            }

//            return Ok(gemeente);
//        }

//        // PUT: api/Gemeentes/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutGemeente([FromRoute] int id, [FromBody] Gemeente gemeente)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != gemeente.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(gemeente).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!GemeenteExists(id))
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

//        // POST: api/Gemeentes
//        [HttpPost]
//        public async Task<IActionResult> PostGemeente([FromBody] Gemeente gemeente)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Gemeentes.Add(gemeente);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (GemeenteExists(gemeente.Id))
//                {
//                    return new StatusCodeResult(StatusCodes.Status409Conflict);
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetGemeente", new { id = gemeente.Id }, gemeente);
//        }

//        // DELETE: api/Gemeentes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGemeente([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var gemeente = await _context.Gemeentes.SingleOrDefaultAsync(m => m.Id == id);
//            if (gemeente == null)
//            {
//                return NotFound();
//            }

//            _context.Gemeentes.Remove(gemeente);
//            await _context.SaveChangesAsync();

//            return Ok(gemeente);
//        }

//        private bool GemeenteExists(int id)
//        {
//            return _context.Gemeentes.Any(e => e.Id == id);
//        }
//    }
//}