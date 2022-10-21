using System;

namespace Berger.Application.Models.User
{
    public class UserResponseModel : UserBaseModel
    {
        public Guid Id { get; set; }

        public string Token { get; set; }
    }
}
