using System;

namespace Berger.Domain.Entities
{
    public class Visit : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PersonId { get; set; }
        public DateOnly Date { get; set; }
        public bool IsDone { get; set; }

        public User UserLoggedIn { get; set; }
        public Person PersonVisited { get; set; }
    }
}
