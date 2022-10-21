using System;

namespace Berger.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool Deleted { get; protected set; }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
