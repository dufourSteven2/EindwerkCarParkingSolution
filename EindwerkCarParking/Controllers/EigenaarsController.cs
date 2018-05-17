//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using EindwerkCarParking.Models;
//using EindwerkCarParkingLib;

//namespace EindwerkCarParking.Controllers
//{
//    public class EigenaarsController : ApiController
//    {
//        private EindwerkCarParkingContext db = new EindwerkCarParkingContext();

//        // GET: api/Eigenaars
//        public IQueryable<Eigenaar> GetEigenaars()
//        {
//            return db.Eigenaars;
//        }

//        // GET: api/Eigenaars/5
//        [ResponseType(typeof(Eigenaar))]
//        public async Task<IHttpActionResult> GetEigenaar(int id)
//        {
//            Eigenaar eigenaar = await db.Eigenaars.FindAsync(id);
//            if (eigenaar == null)
//            {
//                return NotFound();
//            }

//            return Ok(eigenaar);
//        }

//        // PUT: api/Eigenaars/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutEigenaar(int id, Eigenaar eigenaar)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != eigenaar.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(eigenaar).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EigenaarExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Eigenaars
//        [ResponseType(typeof(Eigenaar))]
//        public async Task<IHttpActionResult> PostEigenaar(Eigenaar eigenaar)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Eigenaars.Add(eigenaar);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = eigenaar.Id }, eigenaar);
//        }

//        // DELETE: api/Eigenaars/5
//        [ResponseType(typeof(Eigenaar))]
//        public async Task<IHttpActionResult> DeleteEigenaar(int id)
//        {
//            Eigenaar eigenaar = await db.Eigenaars.FindAsync(id);
//            if (eigenaar == null)
//            {
//                return NotFound();
//            }

//            db.Eigenaars.Remove(eigenaar);
//            await db.SaveChangesAsync();

//            return Ok(eigenaar);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool EigenaarExists(int id)
//        {
//            return db.Eigenaars.Count(e => e.Id == id) > 0;
//        }
//    }
//}