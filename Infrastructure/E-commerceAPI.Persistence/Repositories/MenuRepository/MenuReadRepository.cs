using E_commerceAPI.Application.Repositories.MenuRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.MenuRepository
{
    public class MenuReadRepository : ReadRepository<Menu, ECommerceDbContext>, IMenuReadRepository
    {
        public MenuReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
