using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Berger.Domain.Entities;
using Berger.Infra.Context;
using Berger.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Berger.Infra.Repositories
{
    public class ChurchRepository : GenericRepository<Church>, IChurchRepository
    {
        public ChurchRepository(MainContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ExistsByName(string name)
        {
            return await Query().AnyAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Church>> GetAllByUserId(Guid userId)
        {
            return await Query().Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
