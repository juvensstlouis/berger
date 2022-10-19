namespace Berger.Application.Models.User
{
    public class UserResponseModel : UserBaseModel
    {
        public string Id { get; set; }

        public string Token { get; set; }
    }
}
