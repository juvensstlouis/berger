using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Berger.Domain.Entities;

namespace Berger.Infra.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<bool> ExistsByCode(string code);
        Task<IEnumerable<Person>> GetAllByUserId(Guid userId);
    }
}
