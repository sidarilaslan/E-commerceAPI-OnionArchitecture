using E_commerceAPI.Application.Repositories.OrderRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order, ECommerceDbContext>, IOrderReadRepository
    {
        public OrderReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
