using System;

namespace Berger.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; private set; }
    }
}
