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
        public IEnumerable<Annonce> GetAllAnnonces()
        {
             return _context.Annonces;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Annonce> GetUserAnnonces()
        {
            
            var userId = HttpContext.User.Claims.First().Value;
            return _context.Annonces.Where(a => a.UserId == userId);
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
        [HttpDelete]
        public async Task<IActionResult> DeleteAnnonce([FromBody] Annonce ann)
        {
            if(!ModelState.IsValid)
              return BadRequest(ModelState);
            var annonce =  _context.Annonces.SingleOrDefault(a => a.Id == ann.Id);
            if(annonce == null)
               return NotFound();
            _context.Annonces.Remove(annonce);
            await _context.SaveChangesAsync();
            return Ok(annonce);
            
        }

        private bool AnnonceExists(int id)
        {
            return _context.Annonces.Any(a => a.Id == id);
        }
    }
}