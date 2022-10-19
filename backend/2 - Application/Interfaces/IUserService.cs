using Berger.Application.Models.User;
using System.Threading.Tasks;

namespace Berger.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseModel> Authenticate(UserRequestModel request);
        Task Create(UserRequestModel request);
    }
}
