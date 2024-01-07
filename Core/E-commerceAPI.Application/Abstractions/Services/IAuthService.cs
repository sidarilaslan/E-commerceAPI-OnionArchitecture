using E_commerceAPI.Application.Dtos.User;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> LoginAsync(string email, string password);
        Task PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string userId, string resetToken);
        Task<Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
