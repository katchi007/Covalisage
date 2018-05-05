using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain;
using Microsoft.EntityFrameworkCore;

namespace covalisage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext context;
        public UserRepository(UserDbContext context)
        {
            this.context = context;
        }
        public async Task<User> AddAsync(User user)
        {
                    context.Add(user);
                    await context.SaveChangesAsync();
                    return user;
        }

        public Task<User> FindAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var users =  context.Users.ToList();
           return users;
        }

        public async Task RemoveAsync(string id)
        {
            var user = await context.Users.SingleOrDefaultAsync(m => m.Id == id);
           context.Users.Remove(user);
           await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}