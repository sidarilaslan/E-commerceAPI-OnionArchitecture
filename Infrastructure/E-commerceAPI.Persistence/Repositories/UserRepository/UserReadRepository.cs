using E_commerceAPI.Application.Repositories.UserRepository;
using E_commerceAPI.Domain.Entities.Identity;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<AppUser, ECommerceDbContext>, IUserReadRepository
    {
        public UserReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
