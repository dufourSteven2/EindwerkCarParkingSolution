using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EindwerkCarParking.Models;
using EindwerkCarParkingLib;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace EindwerkCarParking.Controllers
{
    public class ParkingsController : ApiController
    {
        private EindwerkCarParkingContext db = new EindwerkCarParkingContext();

        // GET: api/Parkings
        public IQueryable<ParkingsDTO> GetParkings()
        {
            var parkings = db.Parkings.ProjectTo<ParkingsDTO>();
            return parkings;
        }

        // GET: api/Parkings/5
        [ResponseType(typeof(ParkingsDetailDTO))]
        public async Task<IHttpActionResult> GetParking(int id)
        {
            //Parking parking = await db.Parkings.FindAsync(id);
            var parking = await db.Parkings.ProjectTo<ParkingsDetailDTO>().SingleOrDefaultAsync(p => p.Id == id);
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
            db.Set<Parking>().Attach(parking); //hier de update
            db.Entry(parking).State = EntityState.Modified;
            await db.SaveChangesAsync();

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

            db.Parkings.Add(parking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = parking.Id }, parking);
        }

        // DELETE: api/Parkings/5
        [ResponseType(typeof(Parking))]
        public async Task<IHttpActionResult> DeleteParking(int id)
        {
            Parking parking = await db.Parkings.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }

            db.Parkings.Remove(parking);
            await db.SaveChangesAsync();

            return Ok(parking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParkingExists(int id)
        {
            return db.Parkings.Count(e => e.Id == id) > 0;
        }
    }
}