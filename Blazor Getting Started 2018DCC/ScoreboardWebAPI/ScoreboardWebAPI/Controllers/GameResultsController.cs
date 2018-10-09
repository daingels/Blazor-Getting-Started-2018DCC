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
using System.Web.Http.Cors;
using ScoreboardWebAPI.Models;

namespace ScoreboardWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GameResultsController : ApiController
    {
        private ScoreboardEntities db = new ScoreboardEntities();

        // GET: api/GameResults
        public IQueryable<GameResults> GetGameResults()
        {
            return db.GameResults;
        }

        // GET: api/GameResults/5
        [ResponseType(typeof(GameResults))]
        public async Task<IHttpActionResult> GetGameResults(int id)
        {
            GameResults gameResults = await db.GameResults.FindAsync(id);
            if (gameResults == null)
            {
                return NotFound();
            }

            return Ok(gameResults);
        }

        // PUT: api/GameResults/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGameResults(int id, GameResults gameResults)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameResults.ID)
            {
                return BadRequest();
            }

            db.Entry(gameResults).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameResultsExists(id))
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

        // POST: api/GameResults
        [ResponseType(typeof(GameResults))]
        public async Task<IHttpActionResult> PostGameResults(GameResults gameResults)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameResults.Add(gameResults);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gameResults.ID }, gameResults);
        }

        // DELETE: api/GameResults/5
        [ResponseType(typeof(GameResults))]
        public async Task<IHttpActionResult> DeleteGameResults(int id)
        {
            GameResults gameResults = await db.GameResults.FindAsync(id);
            if (gameResults == null)
            {
                return NotFound();
            }

            db.GameResults.Remove(gameResults);
            await db.SaveChangesAsync();

            return Ok(gameResults);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameResultsExists(int id)
        {
            return db.GameResults.Count(e => e.ID == id) > 0;
        }
    }
}