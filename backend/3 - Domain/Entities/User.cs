using System.Collections.Generic;

namespace Berger.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Church> Churchs { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}
