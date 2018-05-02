using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class AnnonceController : Controller
    {
        readonly CovalisageContext _context;
        public AnnonceController(CovalisageContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllAnnonces()
        {
             var annonces =  _context.Annonces.ToList();
             return this.Ok(annonces);

        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserAnnonces()
        {
            
            var userId = HttpContext.User.Claims.First().Value;
            var annonces =  _context.Annonces.Where(a => a.UserId == userId).ToList();
            return this.Ok(annonces);
        }

        // POST api/values
       [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAnnonce([FromBody] Annonce annonce)
        {
            if(!ModelState.IsValid)
              return BadRequest(ModelState);
            var userId = HttpContext.User.Claims.First().Value;
            annonce.UserId = userId;
            _context.Annonces.Add(annonce);
            await _context.SaveChangesAsync();
            return Ok(annonce);
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnonce(int id, [FromBody]Annonce annonce)
        {
            if(!ModelState.IsValid)
              return BadRequest(ModelState);
            if (id != annonce.Id)
            {
                return BadRequest();
            }

            _context.Entry(annonce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnonceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteAnnonce(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = HttpContext.User.Claims.First().Value;
            var annonce = await _context.Annonces.SingleOrDefaultAsync(m => m.Id == id);
            /*if(annonce == null)
               return NotFound();*/
            if(annonce.UserId == userId)
                _context.Annonces.Remove(annonce);
            else
                return BadRequest();
            await _context.SaveChangesAsync();
            
           return new NoContentResult();
            
        }

        private bool AnnonceExists(int id)
        {
            return _context.Annonces.Any(a => a.Id == id);
        }
    }
}