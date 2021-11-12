using System.Threading.Tasks;
using Berger.Application.Models;

namespace Berger.Application.Interfaces
{
    public interface IChurchService
    {
        Task CreateChurch(ChurchRequestModel churchRequestModel);
    }
}