using E_commerceAPI.Application.Repositories.CategoryRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.CategoryRepository
{
    public class CategoryReadRepository : ReadRepository<Category, ECommerceDbContext>, ICategoryReadRepository
    {
        public CategoryReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
