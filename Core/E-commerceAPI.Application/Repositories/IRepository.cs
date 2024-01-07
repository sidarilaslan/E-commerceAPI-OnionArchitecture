using E_commerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace E_commerceAPI.Application.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        DbSet<T> Table { get; }
    }
}
