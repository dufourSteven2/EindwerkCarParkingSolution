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
using AutoMapper;
using System.Web.Http.Description;

namespace EindwerkCarParkingCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Parkings")]
    public class ParkingsController : Controller
    {
        private readonly EindwerkCarParkingContext _context;
        private readonly IMapper _mapper;

        public ParkingsController(EindwerkCarParkingContext context)
        {
            _context = context;
            //IMapper _Mapper;
        }

        // GET: api/Parkings
        [HttpGet]
        public IEnumerable<ParkingsDTO> GetParkings()
        {
            var parkings = _context.Parkings.ProjectTo<ParkingsDTO>();
            return parkings;
            //return _context.Parkings;
        }

        // GET: api/Parkings/5
        [HttpGet("{id}")]
        //[ResponseType(typeof(ParkingsDetailDTO))]
        public async Task<IActionResult> GetParking([FromRoute] int id)
        {
            //var parking = await _context.Parkings.ProjectTo<ParkingsDetailDTO>().SingleOrDefaultAsync(p => p.Id == id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parking = await _context.Parkings.ProjectTo<ParkingsDetailDTO>().SingleOrDefaultAsync(m => m.Id == id);
            //var parking = await _context.Parkings.SingleOrDefaultAsync(m => m.Id == id);

            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking);
        }

        // PUT: api/Parkings/5
        [HttpPut("{id}")]
        //public async Task<IHttpActionResult> PutParking(int id, ParkingsDetailDTO parkingsDetailDTO)
        public async Task<IActionResult> PutParking([FromRoute] int id, [FromBody] ParkingsDetailDTO parkingsDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Parking parking = Mapper.Map<Parking>(parkingsDetailDTO);
            _context.Set<Parking>().Attach(parking); //hier de update
            _context.Entry(parking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(parkingsDetailDTO);


            //if (id != parkingsDetailDTO.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(parkingsDetailDTO).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ParkingExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Parkings
        [HttpPost]
        public async Task<IActionResult> PostParking([FromBody] Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Parkings.Add(parking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParkingExists(parking.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParking", new { id = parking.Id }, parking);
        }

        // DELETE: api/Parkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parking = await _context.Parkings.SingleOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();

            return Ok(parking);
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }
    }
}