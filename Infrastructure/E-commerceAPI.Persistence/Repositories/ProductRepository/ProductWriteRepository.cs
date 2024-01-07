using E_commerceAPI.Application.Repositories.ProductRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.ProductRepository
{
    public class ProductWriteRepository : WriteRepository<Product, ECommerceDbContext>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
