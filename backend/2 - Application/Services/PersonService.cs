using Berger.Application.Interfaces;
using Berger.Application.Models.Person;
using Berger.Domain.Entities;
using Berger.Domain.Exceptions;
using Berger.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berger.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUserRepository _userRepository;

        public PersonService(IPersonRepository personRepository, IUserRepository userRepository)
        {
            _personRepository = personRepository;
            _userRepository = userRepository;
        }

        public async Task CreatePerson(PersonRequestModel personRequestModel, Guid userId)
        {
            var isPersonExists = await _personRepository.ExistsByCode(personRequestModel.Code);

            if (isPersonExists)
            {
                throw new BadRequestException($"Pessoa com esse código já cadastrada.");
            }

            var person = new Person
            {
                UserId = userId,
                Code = personRequestModel.Code,
                Name = personRequestModel.Name,
                Address = personRequestModel.Address,
                PhoneNumber = personRequestModel.PhoneNumber,
                ChurchId = new Guid(personRequestModel.ChurchId)
            };
            await _personRepository.Create(person);
            await _personRepository.Save();
        }

        public async Task<IEnumerable<PersonResponseModel>> GetAllPeople(Guid userId)
        {
            var persons = await _personRepository.GetAllByUserId(userId);

            return persons.Select(person => new PersonResponseModel
            {
                Id = person.Id.ToString(),
                Code = person.Code,
                Name = person.Name,
                Address = person.Address,
                PhoneNumber = person.PhoneNumber,
                //Church
            });
        }
    }
}