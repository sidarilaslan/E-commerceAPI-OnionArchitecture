using E_commerceAPI.Application.Repositories.FileRepository;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.FileRepository
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File, ECommerceDbContext>, IFileReadRepository
    {
        public FileReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
