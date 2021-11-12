using Berger.Domain.Entities;
using Berger.Infra.Context;
using Berger.Infra.Interfaces;

namespace Berger.Infra.Repositories
{
    public class ChurchRepository : GenericRepository<Church>, IChurchRepository
    {
        public ChurchRepository(MainContext dbContext) : base(dbContext)
        {
            
        }
    }
}
