using E_commerceAPI.Application.Repositories.BasketRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.BasketRepository
{
    public class BasketWriteRepository : WriteRepository<Basket, ECommerceDbContext>, IBasketWriteRepository
    {
        public BasketWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
