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
    public class SoortsController : ApiController
    {
        private EindwerkCarParkingContext db = new EindwerkCarParkingContext();

        // GET: api/Soorts
        public IQueryable<Soort> GetSoorts()
        {
            return db.Soorts;
        }

        // GET: api/Soorts/5
        [ResponseType(typeof(Soort))]
        public async Task<IHttpActionResult> GetSoort(int id)
        {
            Soort soort = await db.Soorts.FindAsync(id);
            if (soort == null)
            {
                return NotFound();
            }

            return Ok(soort);
        }

        // PUT: api/Soorts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSoort(int id, Soort soort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soort.Id)
            {
                return BadRequest();
            }

            db.Entry(soort).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoortExists(id))
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

        // POST: api/Soorts
        [ResponseType(typeof(Soort))]
        public async Task<IHttpActionResult> PostSoort(Soort soort)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Soorts.Add(soort);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = soort.Id }, soort);
        }

        // DELETE: api/Soorts/5
        [ResponseType(typeof(Soort))]
        public async Task<IHttpActionResult> DeleteSoort(int id)
        {
            Soort soort = await db.Soorts.FindAsync(id);
            if (soort == null)
            {
                return NotFound();
            }

            db.Soorts.Remove(soort);
            await db.SaveChangesAsync();

            return Ok(soort);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoortExists(int id)
        {
            return db.Soorts.Count(e => e.Id == id) > 0;
        }
    }
}