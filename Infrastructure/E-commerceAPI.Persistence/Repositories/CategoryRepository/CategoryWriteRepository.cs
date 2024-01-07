using E_commerceAPI.Application.Repositories.CategoryRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category, ECommerceDbContext>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
