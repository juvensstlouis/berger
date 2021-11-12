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
                    ZipCode = churchRequestModel.Address?.ZipCode,
                    Street = churchRequestModel.Address?.Street,
                    Number = churchRequestModel.Address?.Number,
                    Complement = churchRequestModel.Address?.Complement,
                    Neighborhood = churchRequestModel.Address?.Neighborhood,
                    City = churchRequestModel.Address?.City,
                    State = churchRequestModel.Address?.State,
                }
            };

            await _churchRepository.Create(church);
            await _churchRepository.Save();
        }
    }
}