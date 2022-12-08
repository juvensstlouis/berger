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
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MainContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ExistsByCode(string code)
        {
            return await Query().AnyAsync(c => c.Code == code);
        }

        public async Task<IEnumerable<Person>> GetAllByUserId(Guid userId)
        {
            return await Query().Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
