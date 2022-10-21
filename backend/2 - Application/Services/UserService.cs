using Berger.Application.Interfaces;
using Berger.Application.Models.User;
using Berger.Domain.Entities;
using Berger.Domain.Exceptions;
using Berger.Infra.Interfaces;
using Berger.Infra.Repositories;
using System;
using System.Threading.Tasks;

namespace Berger.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseModel> Authenticate(UserRequestModel request)
        {
            request.Username = request.Username.Trim();

            //int workfactor = 10;
            //string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);//, salt);

            var user = await _userRepository.GetByUsername(request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new NotFoundException("Usuário ou senha inválidos");
            }

            var token = TokenService.GenerateToken(user);

            return new UserResponseModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Token = token
            };
        }

        public async Task Create(UserRequestModel request)
        {
            request.Username = request.Username.Trim();

            var user = await _userRepository.GetByUsername(request.Username);

            if (user != null)
            {
                throw new BadRequestException("Nome de usuário já existente.");
            }

            //int workfactor = 10;
            //string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);//, salt);

            user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = passwordHash
            };

            await _userRepository.Create(user);
            await _userRepository.Save();
        }
    }
}
