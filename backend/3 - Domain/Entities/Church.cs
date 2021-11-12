using System;
using Berger.Domain.ComplexTypes;

namespace Berger.Domain.Entities
{

    public class Church : BaseEntity
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public Address Address { get; set; }
    }
}