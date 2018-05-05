using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain;

namespace covalisage.Repositories
{

    public interface IAnnonceRepository
    {
    Task<Annonce> AddAsync(Annonce annonce);
    IEnumerable<Annonce> GetAll();
    Task<Annonce> FindAsync(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(Annonce annonce);
    }
}