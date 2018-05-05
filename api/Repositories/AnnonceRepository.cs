using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain;
using Microsoft.EntityFrameworkCore;

namespace covalisage.Repositories
{
    public class AnnonceRepository : IAnnonceRepository
    {
        private readonly CovalisageContext context;
        public AnnonceRepository(CovalisageContext context)
        {
            this.context = context;
        }
        public async Task<Annonce> AddAsync(Annonce annonce)
        {
                    context.Add(annonce);
                    await context.SaveChangesAsync();
                    return annonce;
        }

        public Task<Annonce> FindAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Annonce> GetAll()
        {
           var annonces =  context.Annonces.ToList();
           return annonces;
        }

        public async Task RemoveAsync(int id)
        {
           var annonce = await context.Annonces.SingleOrDefaultAsync(m => m.Id == id);
           context.Annonces.Remove(annonce);
           await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Annonce annonce)
        {
            context.Entry(annonce).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}