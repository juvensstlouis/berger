using Berger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Berger.Infra.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        void Update(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Save();
    }
}
