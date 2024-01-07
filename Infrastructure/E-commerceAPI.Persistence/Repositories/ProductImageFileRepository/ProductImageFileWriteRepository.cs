using E_commerceAPI.Application.Repositories.ProductImageFileRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.ProductImageFileRepository
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile, ECommerceDbContext>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
