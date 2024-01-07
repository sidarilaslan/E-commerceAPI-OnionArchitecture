namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IUserRoleService
    {
        Task<bool> CreateRole(string roleName);
        Task<bool> HardDeleteRole(string roleId);
        Task<bool> UpdateRole(Guid roleId, string name);
        (object, int) GetAllRoles(int page, int size);
        Task<(Guid roleId, string roleName)> GetRoleById(Guid roleId);

    }
}
