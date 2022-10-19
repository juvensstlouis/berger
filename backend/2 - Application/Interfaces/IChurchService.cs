using System.Collections.Generic;
using System.Threading.Tasks;
using Berger.Application.Models.Church;

namespace Berger.Application.Interfaces
{
    public interface IChurchService
    {
        Task CreateChurch(ChurchRequestModel churchRequestModel);
        Task<IEnumerable<ChurchResponseModel>> GetAllChurchs();
    }
}