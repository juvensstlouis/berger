using System.Threading.Tasks;
using Berger.Application.Interfaces;
using Berger.Application.Models;
using Berger.Domain.ComplexTypes;
using Berger.Domain.Entities;
using Berger.Infra.Interfaces;

namespace Berger.Application.Services
{
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _churchRepository;

        public ChurchService(IChurchRepository churchRepository)
        {
            _churchRepository = churchRepository;
        }

        public async Task CreateChurch(ChurchRequestModel churchRequestModel)
        {
            var church = new Church
            {
                Name = churchRequestModel.Name,
                FoundationDate = churchRequestModel.FoundationDate,
                Address = new Address
                {
                    ZipCode = churchRequestModel.ZipCode,
                    Street = churchRequestModel.Street,
                    Number = churchRequestModel.Number,
                    Complement = churchRequestModel.Complement,
                    Neighborhood = churchRequestModel.Neighborhood,
                    City = churchRequestModel.City,
                    State = churchRequestModel.State,
                }
            };

            await _churchRepository.Create(church);
            await _churchRepository.Save();
        }
    }
}