using E_commerceAPI.Domain.Entities.Identity;

namespace E_commerceAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<Dtos.Token> CreateAccessToken(AppUser user);
    }
}
