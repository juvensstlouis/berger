using Berger.Application.Interfaces;
using Berger.Application.Models.Church;
using Berger.Domain.Entities;
using Berger.Domain.Exceptions;
using Berger.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Berger.Application.Services
{
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _churchRepository;
        private readonly IUserRepository _userRepository;

        public ChurchService(IChurchRepository churchRepository, IUserRepository userRepository)
        {
            _churchRepository = churchRepository;
            _userRepository = userRepository;
        }

        public async Task CreateChurch(ChurchRequestModel churchRequestModel, Guid userId)
        {
            var isChurchExists = await _churchRepository.ExistsByName(churchRequestModel.Name);

            if (isChurchExists)
            {
                throw new BadRequestException("Igreja já cadastrada.");
            }

            var church = new Church
            {
                UserId = userId,
                Name = churchRequestModel.Name
            };
            await _churchRepository.Create(church);
            await _churchRepository.Save();
        }

        public async Task<IEnumerable<ChurchResponseModel>> GetAllChurchs(Guid userId)
        {
            var churchs = await _churchRepository.GetAllByUserId(userId);

            return churchs.Select(church => new ChurchResponseModel
            {
                Id = church.Id.ToString(),
                Name = church.Name,
            });
        }
    }
}