using E_commerceAPI.Application.Repositories.CompletedOrderRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.CompletedOrderRepository
{
    public class CompletedOrderWriteRepository : WriteRepository<CompletedOrder, ECommerceDbContext>, ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
