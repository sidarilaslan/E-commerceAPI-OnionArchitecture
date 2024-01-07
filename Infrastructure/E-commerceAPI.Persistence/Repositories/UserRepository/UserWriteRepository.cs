using E_commerceAPI.Application.Repositories.UserRepository;
using E_commerceAPI.Domain.Entities.Identity;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.UserRepository
{
    public class UserWriteRepository : WriteRepository<AppUser, ECommerceDbContext>, IUserWriteRepository
    {
        public UserWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
