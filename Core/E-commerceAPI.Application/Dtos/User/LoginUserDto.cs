namespace E_commerceAPI.Application.Dtos.User
{
    public class LoginUserResponseDto
    {
        public UserDto UserDto { get; set; }
        public Dtos.Token Token { get; set; }
    }
}
