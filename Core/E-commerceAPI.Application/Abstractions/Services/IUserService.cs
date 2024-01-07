using E_commerceAPI.Application.Dtos.User;
using E_commerceAPI.Domain.Entities.Identity;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto createUserDto);
        Task UpdatePasswordAsync(Guid userId, string password, string resetToken);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate);
        Task DeleteUser(Guid userId);
        Task HardDeleteUser(Guid userId);
        Task<AppUser> GetByIdAsync(Guid userId);
        Task<ListUserDto> GetAllUsersAsync(int page, int size);
        Task AssignRoleToUserAsnyc(Guid userId, string[] roles);
        Task<string[]> GetRolesToUserAsync(Guid userId);
        Task<bool> HasRolePermissionToEndpointAsync(Guid userId, string code);
    }
}
