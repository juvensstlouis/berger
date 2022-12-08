using System;

namespace Berger.Domain.Entities
{
    public class Preaching : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ChurchId { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }


        public User UserLoggedIn { get; set; }
    }
}
