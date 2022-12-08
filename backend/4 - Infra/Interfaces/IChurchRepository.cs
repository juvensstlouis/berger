using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Berger.Domain.Entities;

namespace Berger.Infra.Interfaces
{
    public interface IChurchRepository : IGenericRepository<Church>
    {
        Task<bool> ExistsByName(string name);
        Task<IEnumerable<Church>> GetAllByUserId(Guid userId);
    }
}
