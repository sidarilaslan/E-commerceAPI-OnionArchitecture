using E_commerceAPI.Application.Abstractions.Services;
using E_commerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace E_commerceAPI.Persistence.Services
{
    public class UserRoleService : IUserRoleService
    {
        private RoleManager<AppRole> _roleManager;

        public UserRoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string roleName)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid(), Name = roleName });

            return result.Succeeded;
        }

        public async Task<bool> HardDeleteRole(string roleId)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(roleId);
            IdentityResult result = await _roleManager.DeleteAsync(appRole);
            return result.Succeeded;
        }

        public (object, int) GetAllRoles(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<AppRole> rolesQuery = null;

            if (page != -1 && size != -1)
                rolesQuery = query.Skip(page * size).Take(size);
            else
                rolesQuery = query;

            return (rolesQuery.Select(r => new { r.Id, r.Name }), query.Count());
        }

        public async Task<(Guid roleId, string roleName)> GetRoleById(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            return (roleId, role.Name);
        }

        public async Task<bool> UpdateRole(Guid roleId, string name)
        {
            AppRole role = await _roleManager.FindByIdAsync(roleId.ToString());
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
