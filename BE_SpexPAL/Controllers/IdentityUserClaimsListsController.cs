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
using BE_SpexPAL.DataContext;
using BE_SpexPAL.Models;

namespace BE_SpexPAL.Controllers
{
    [RoutePrefix("api/newclaims")]
    public class IdentityUserClaimsListsController : ApiController
    {
        private SpexPalDbContext db = new SpexPalDbContext();

        // GET: api/IdentityUserClaimsLists
        [Route("GetLists")]
        public IQueryable<IdentityUserClaimsList> GetIdentityUserClaimsLists()
        {
            return db.IdentityUserClaimsLists;
        }

        // GET: api/IdentityUserClaimsLists/5
          [Route("GetLists")]
        [ResponseType(typeof(IdentityUserClaimsList))]
        public async Task<IHttpActionResult> GetIdentityUserClaimsList(Guid id)
        {
            IdentityUserClaimsList identityUserClaimsList = await db.IdentityUserClaimsLists.FindAsync(id);
            if (identityUserClaimsList == null)
            {
                return NotFound();
            }

            return Ok(identityUserClaimsList);
        }

        // PUT: api/IdentityUserClaimsLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIdentityUserClaimsList(Guid id, IdentityUserClaimsList identityUserClaimsList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != identityUserClaimsList.Id)
            {
                return BadRequest();
            }

            db.Entry(identityUserClaimsList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityUserClaimsListExists(id))
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

        // POST: api/IdentityUserClaimsLists
         [Route("postclaim")]
        [ResponseType(typeof(IdentityUserClaimsList))]
        public async Task<IHttpActionResult> PostIdentityUserClaimsList(IdentityUserClaimsList identityUserClaimsList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IdentityUserClaimsLists.Add(identityUserClaimsList);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IdentityUserClaimsListExists(identityUserClaimsList.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = identityUserClaimsList.Id }, identityUserClaimsList);
        }

        // DELETE: api/IdentityUserClaimsLists/5
        [ResponseType(typeof(IdentityUserClaimsList))]
        public async Task<IHttpActionResult> DeleteIdentityUserClaimsList(Guid id)
        {
            IdentityUserClaimsList identityUserClaimsList = await db.IdentityUserClaimsLists.FindAsync(id);
            if (identityUserClaimsList == null)
            {
                return NotFound();
            }

            db.IdentityUserClaimsLists.Remove(identityUserClaimsList);
            await db.SaveChangesAsync();

            return Ok(identityUserClaimsList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdentityUserClaimsListExists(Guid id)
        {
            return db.IdentityUserClaimsLists.Count(e => e.Id == id) > 0;
        }
    }
}