using E_commerceAPI.Application.Repositories.BasketItemRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.BasketItemRepository
{
    public class BasketItemReadRepository : ReadRepository<BasketItem, ECommerceDbContext>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
