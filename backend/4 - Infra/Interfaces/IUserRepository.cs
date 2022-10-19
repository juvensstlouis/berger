using Berger.Domain.Entities;
using System.Threading.Tasks;

namespace Berger.Infra.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Get(string username, string password);
        Task<User> GetByUsername(string username);
    }
}
