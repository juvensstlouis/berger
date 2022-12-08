using System;

namespace Berger.Domain.Entities
{
    public class Person : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid ChurchId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public User UserLoggedIn { get; set; }
        public Church Church { get; set; }
    }
}