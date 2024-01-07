using E_commerceAPI.Application.Repositories.OrderRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Order, ECommerceDbContext>, IOrderWriteRepository
    {
        public OrderWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
