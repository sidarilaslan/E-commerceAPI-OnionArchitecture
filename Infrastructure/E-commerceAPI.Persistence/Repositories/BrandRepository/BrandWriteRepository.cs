using E_commerceAPI.Application.Repositories.BrandRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.BrandRepository
{
    public class BrandWriteRepository : WriteRepository<Brand, ECommerceDbContext>, IBrandWriteRepository
    {
        public BrandWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
