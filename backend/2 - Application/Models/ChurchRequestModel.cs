using System;

namespace Berger.Application.Models
{
    public class ChurchRequestModel
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
