using E_commerceAPI.Application.Repositories.ProductRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.ProductRepository
{
    public class ProductReadRepository : ReadRepository<Product, ECommerceDbContext>, IProductReadRepository
    {
        public ProductReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
