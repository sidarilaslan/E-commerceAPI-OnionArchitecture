using E_commerceAPI.Application.Dtos.User;

namespace E_commerceAPI.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandResponse
    {
        public UserDto User { get; set; }
        public Dtos.Token Token { get; set; }
    }
}
