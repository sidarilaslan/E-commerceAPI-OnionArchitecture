using E_commerceAPI.Application.Repositories.EndpointRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.EndpointRepository
{
    public class EndpointReadRepository : ReadRepository<Endpoint, ECommerceDbContext>, IEndpointReadRepository
    {
        public EndpointReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
