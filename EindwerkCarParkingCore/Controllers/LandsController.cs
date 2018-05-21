//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using EindwerkCarParkingCore.Data;
//using EindwerkCarParkingLib;
//using AutoMapper.QueryableExtensions;
//using EindwerkCarParkingCore.Models;

//namespace EindwerkCarParkingCore.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/Lands")]
//    public class LandsController : Controller
//    {
//        private readonly EindwerkCarParkingContext _context;

//        public LandsController(EindwerkCarParkingContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Lands
//        [HttpGet]
//        public IEnumerable<LandDTO> GetLands()
//        {
//            //return _context.Lands;
//            return _context.Lands.ProjectTo<LandDTO>();
//        }

//        // GET: api/Lands/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetLand([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var land = await _context.Lands.SingleOrDefaultAsync(m => m.Id == id);

//            if (land == null)
//            {
//                return NotFound();
//            }

//            return Ok(land);
//        }

//        // PUT: api/Lands/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutLand([FromRoute] int id, [FromBody] Land land)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != land.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(land).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!LandExists(id))
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

//        // POST: api/Lands
//        [HttpPost]
//        public async Task<IActionResult> PostLand([FromBody] Land land)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Lands.Add(land);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (LandExists(land.Id))
//                {
//                    return new StatusCodeResult(StatusCodes.Status409Conflict);
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetLand", new { id = land.Id }, land);
//        }

//        // DELETE: api/Lands/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteLand([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var land = await _context.Lands.SingleOrDefaultAsync(m => m.Id == id);
//            if (land == null)
//            {
//                return NotFound();
//            }

//            _context.Lands.Remove(land);
//            await _context.SaveChangesAsync();

//            return Ok(land);
//        }

//        private bool LandExists(int id)
//        {
//            return _context.Lands.Any(e => e.Id == id);
//        }
//    }
//}