using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Berger.Application.Models.Person;

namespace Berger.Application.Interfaces
{
    public interface IPersonService
    {
        Task CreatePerson(PersonRequestModel personRequestModel, Guid userId);
        Task<IEnumerable<PersonResponseModel>> GetAllPeople(Guid userId);
    }
}