using E_commerceAPI.Application.Repositories.FileRepository;
using E_commerceAPI.Persistence.Contexts.EntityFramework;

namespace E_commerceAPI.Persistence.Repositories.FileRepository
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.File, ECommerceDbContext>, IFileWriteRepository
    {
        public FileWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
