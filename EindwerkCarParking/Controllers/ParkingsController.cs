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

namespace EindwerkCarParking.Controllers
{
    public class ParkingsController : ApiController
    {
        private EindwerkCarParkingContext db = new EindwerkCarParkingContext();

        // GET: api/Parkings
        public IQueryable<Parking> GetParkings()
        {
            return db.Parkings;
        }

        // GET: api/Parkings/5
        [ResponseType(typeof(Parking))]
        public async Task<IHttpActionResult> GetParking(int id)
        {
            Parking parking = await db.Parkings.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking);
        }

        // PUT: api/Parkings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParking(int id, Parking parking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parking.Id)
            {
                return BadRequest();
            }

            db.Entry(parking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
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