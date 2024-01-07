using E_commerceAPI.Application.Dtos.AuthorizationConfigration;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IAppService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
