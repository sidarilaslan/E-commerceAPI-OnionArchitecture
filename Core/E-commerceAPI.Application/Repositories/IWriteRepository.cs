using E_commerceAPI.Domain.Entities.Common;

namespace E_commerceAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<T> entities);
        Task<int> SaveAsync();
    }
}
