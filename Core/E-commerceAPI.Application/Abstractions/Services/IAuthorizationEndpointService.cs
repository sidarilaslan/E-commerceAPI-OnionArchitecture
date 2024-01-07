namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IAuthorizationEndpointService
    {
        public Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type);
        public Task<List<string>> GetAssignedRolesToEndpointAsync(string code, string menu);
    }
}
