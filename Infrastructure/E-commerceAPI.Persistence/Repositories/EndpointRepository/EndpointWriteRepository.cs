using E_commerceAPI.Application.Repositories.EndpointRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.EndpointRepository
{
    public class EndpointWriteRepository : WriteRepository<Endpoint, ECommerceDbContext>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
