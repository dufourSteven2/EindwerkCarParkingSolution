using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using EindwerkCarParkingCore.Data;
using EindwerkCarParkingLib;
using AutoMapper.QueryableExtensions;
using EindwerkCarParkingCore.Models;
using AutoMapper;
using System.Web.Http;
using System.Web.Http.Description;

namespace EindwerkCarParkingCore.Controllers
{
    public class ParkingsController : ApiController
    {
        private readonly EindwerkCarParkingContext _context;
        private readonly IMapper _mapper;

        public ParkingsController(EindwerkCarParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Parkings
        public IQueryable<ParkingsDTO> GetParkings()
        {
            var parkings = _context.Parkings.ProjectTo<ParkingsDTO>();
            return parkings;
        }

        // GET: api/Parkings/5
        [ResponseType(typeof(ParkingsDetailDTO))]
        public async Task<IHttpActionResult> GetParking(int id)
        {
            //Parking parking = await db.Parkings.FindAsync(id);
            var parking = await _context.Parkings.ProjectTo<ParkingsDetailDTO>().SingleOrDefaultAsync(p => p.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking);
        }

        // PUT: api/Parkings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParking(int id, ParkingsDetailDTO parkingsDetailDTO)
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
        }

        // POST: api/Parkings
        [ResponseType(typeof(Parking))]
        public async Task<IHttpActionResult> PostParking(Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Parkings.Add(parking);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = parking.Id }, parking);
        }

        // DELETE: api/Parkings/5
        [ResponseType(typeof(Parking))]
        public async Task<IHttpActionResult> DeleteParking(int id)
        {
            Parking parking = await _context.Parkings.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }

            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();

            return Ok(parking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Count(e => e.Id == id) > 0;
        }
    }
}
