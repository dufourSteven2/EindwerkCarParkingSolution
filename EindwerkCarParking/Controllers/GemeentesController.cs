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
//using AutoMapper.QueryableExtensions;

//namespace EindwerkCarParking.Controllers
//{
//    public class GemeentesController : ApiController
//    {
//        private EindwerkCarParkingContext db = new EindwerkCarParkingContext();

//        // GET: api/Gemeentes
//        public IQueryable<GemeenteDTO> GetGemeentes()
//        {
//            //return db.Gemeentes;
//            return db.Gemeentes.ProjectTo<GemeenteDTO>();
//        }

//        // GET: api/Gemeentes/5
//        [ResponseType(typeof(Gemeente))]
//        public async Task<IHttpActionResult> GetGemeente(int id)
//        {
//            Gemeente gemeente = await db.Gemeentes.FindAsync(id);
//            if (gemeente == null)
//            {
//                return NotFound();
//            }

//            return Ok(gemeente);
//        }

//        // PUT: api/Gemeentes/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutGemeente(int id, Gemeente gemeente)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != gemeente.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(gemeente).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
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

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Gemeentes
//        [ResponseType(typeof(Gemeente))]
//        public async Task<IHttpActionResult> PostGemeente(Gemeente gemeente)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Gemeentes.Add(gemeente);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = gemeente.Id }, gemeente);
//        }

//        // DELETE: api/Gemeentes/5
//        [ResponseType(typeof(Gemeente))]
//        public async Task<IHttpActionResult> DeleteGemeente(int id)
//        {
//            Gemeente gemeente = await db.Gemeentes.FindAsync(id);
//            if (gemeente == null)
//            {
//                return NotFound();
//            }

//            db.Gemeentes.Remove(gemeente);
//            await db.SaveChangesAsync();

//            return Ok(gemeente);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool GemeenteExists(int id)
//        {
//            return db.Gemeentes.Count(e => e.Id == id) > 0;
//        }
//    }
//}