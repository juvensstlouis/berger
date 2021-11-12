using System;

namespace Berger.Application.Models
{
    public class ChurchRequestModel
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public AddressRequestModel Address { get; set; }
    }
}
