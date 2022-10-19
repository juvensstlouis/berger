using Berger.Domain.Entities;
using Berger.Infra.Context;
using Berger.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Berger.Infra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> Get(string username, string password)
        {
            return await Query().Where(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.Equals(password))
                                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await Query().Where(u => u.Username.ToLower().Equals(username.ToLower()))
                                .FirstOrDefaultAsync();
        }
    }
}
