using E_commerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace E_commerceAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
