using Berger.Application.Interfaces;
using Berger.Application.Models.Church;
using Berger.Domain.ComplexTypes;
using Berger.Domain.Entities;
using Berger.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ChurchResponseModel>> GetAllChurchs()
        {
            var churchs = await _churchRepository.GetAll();

            return churchs.Select(church => new ChurchResponseModel
            {
                Name = church.Name,
                ZipCode = church.Address?.ZipCode,
                Street = church.Address?.Street,
                Number = church.Address?.Number,
                Complement = church.Address?.Complement,
                Neighborhood = church.Address?.Neighborhood,
                City = church.Address?.City,
                State = church.Address?.State,
            });
        }
    }
}