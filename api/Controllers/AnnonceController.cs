using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covalisage.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace covalisage.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AnnonceController : Controller
    {
        readonly MyWebApiContext _context;
        public AnnonceController(MyWebApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IEnumerable<Annonce> GetAllAnnonces()
        {
             return _context.Annonces.ToList();
        }

        [Authorize]
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IEnumerable<Annonce> GetUserAnnonces()
        {
            var userId = HttpContext.User.Claims.First().Value;
            return _context.Annonces.Where(a => a.UserId == userId);
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAnnonceById([FromRoute] int annonceId)
        {
            if(!ModelState.IsValid)
              return BadRequest(ModelState);
            var annonce = await _context.Annonces.SingleOrDefaultAsync(a => a.Id == annonceId);
            if(annonce == null)
               return NotFound();

            return Ok(annonce);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [HttpPut("{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutAnnonce([FromRoute] int id, [FromBody]Annonce annonce)
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
        [HttpDelete("{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnnonce([FromRoute] int id)
        {
            if(!ModelState.IsValid)
              return BadRequest(ModelState);
            var annonce =  _context.Annonces.SingleOrDefault(a => a.Id == id);
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