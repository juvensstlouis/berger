using System;

namespace Berger.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool Deleted { get; protected set; }
        public DateTime CreatedAt { get; protected set; } 
        public DateTime UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        protected void SetUpdateDateToNow()
        {
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
