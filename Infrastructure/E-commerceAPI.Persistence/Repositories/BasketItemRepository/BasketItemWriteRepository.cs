using E_commerceAPI.Application.Repositories.BasketItemRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.BasketItemRepository
{
    public class BasketItemWriteRepository : WriteRepository<BasketItem, ECommerceDbContext>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
