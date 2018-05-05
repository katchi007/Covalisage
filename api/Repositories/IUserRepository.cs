using System.Collections.Generic;
using System.Threading.Tasks;
using api.Domain;

namespace covalisage.Repositories
{
    public interface IUserRepository
    {
    Task<User> AddAsync(User user);
    IEnumerable<User> GetAll();
    Task<User> FindAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(User user);
    }
}