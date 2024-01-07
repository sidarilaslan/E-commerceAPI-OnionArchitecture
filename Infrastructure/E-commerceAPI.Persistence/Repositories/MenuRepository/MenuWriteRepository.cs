using E_commerceAPI.Application.Repositories.MenuRepository;
using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.MenuRepository
{
    public class MenuWriteRepository : WriteRepository<Menu, ECommerceDbContext>, IMenuWriteRepository
    {
        public MenuWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
