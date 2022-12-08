using System;
using System.Collections.Generic;

namespace Berger.Domain.Entities
{
    public class Church : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public User UserLoggedIn { get; set; }
        public IEnumerable<Person> Members { get; set; }
    }
}