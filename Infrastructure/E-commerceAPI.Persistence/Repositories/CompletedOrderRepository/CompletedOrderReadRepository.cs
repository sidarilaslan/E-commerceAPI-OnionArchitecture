using E_commerceAPI.Application.Repositories.CompletedOrderRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.CompletedOrderRepository
{
    internal class CompletedOrderReadRepository : ReadRepository<CompletedOrder, ECommerceDbContext>, ICompletedOrderReadRepository
    {
        public CompletedOrderReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
