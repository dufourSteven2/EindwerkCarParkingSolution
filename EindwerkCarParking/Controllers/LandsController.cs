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
//    public class LandsController : ApiController
//    {
//        private EindwerkCarParkingContext db = new EindwerkCarParkingContext();

//        // GET: api/Lands
//        public IQueryable<LandDTO> GetLands()
//        {
//            //return db.Lands;
//            return db.Lands.ProjectTo<LandDTO>();
//        }

//        // GET: api/Lands/5
//        [ResponseType(typeof(Land))]
//        public async Task<IHttpActionResult> GetLand(int id)
//        {
//            Land land = await db.Lands.FindAsync(id);
//            if (land == null)
//            {
//                return NotFound();
//            }

//            return Ok(land);
//        }

//        // PUT: api/Lands/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutLand(int id, Land land)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != land.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(land).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
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

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Lands
//        [ResponseType(typeof(Land))]
//        public async Task<IHttpActionResult> PostLand(Land land)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Lands.Add(land);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = land.Id }, land);
//        }

//        // DELETE: api/Lands/5
//        [ResponseType(typeof(Land))]
//        public async Task<IHttpActionResult> DeleteLand(int id)
//        {
//            Land land = await db.Lands.FindAsync(id);
//            if (land == null)
//            {
//                return NotFound();
//            }

//            db.Lands.Remove(land);
//            await db.SaveChangesAsync();

//            return Ok(land);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool LandExists(int id)
//        {
//            return db.Lands.Count(e => e.Id == id) > 0;
//        }
//    }
//}