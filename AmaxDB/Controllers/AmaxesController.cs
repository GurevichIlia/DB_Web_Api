using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AmaxDB.Models;

namespace AmaxDB.Controllers
{
    public class AmaxesController : ApiController
    {
        private Amax_DBEntities db = new Amax_DBEntities();

        // GET: api/Amaxes
        public IQueryable<Amax> GetAmax()
        {
            return db.Amax;
        }

        // GET: api/Amaxes/5
        [ResponseType(typeof(Amax))]
        public IHttpActionResult GetAmax(int id)
        {
            Amax amax = db.Amax.Find(id);
            if (amax == null)
            {
                return NotFound();
            }

            return Ok(amax);
        }

        // PUT: api/Amaxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmax(int id, Amax amax)
        {
            

            if (id != amax.id)
            {
                return BadRequest();
            }

            db.Entry(amax).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmaxExists(id))
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

        // POST: api/Amaxes
        [ResponseType(typeof(Amax))]
        public IHttpActionResult PostAmax(Amax amax)
        {

            db.Amax.Add(amax);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = amax.id }, amax);
        }

        // DELETE: api/Amaxes/5
        [ResponseType(typeof(Amax))]
        public IHttpActionResult DeleteAmax(int id)
        {
            Amax amax = db.Amax.Find(id);
            if (amax == null)
            {
                return NotFound();
            }

            db.Amax.Remove(amax);
            db.SaveChanges();

            return Ok(amax);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmaxExists(int id)
        {
            return db.Amax.Count(e => e.id == id) > 0;
        }
    }
}