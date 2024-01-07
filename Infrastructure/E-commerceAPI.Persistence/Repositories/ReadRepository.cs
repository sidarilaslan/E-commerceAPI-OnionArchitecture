using E_commerceAPI.Application.Repositories;
using E_commerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_commerceAPI.Persistence.Repositories
{
    public class ReadRepository<T, TContext> : IReadRepository<T> where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public ReadRepository(TContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll(bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            IQueryable<T> query = Table.Where(predicate);
            if (!tracking)
                query = Table.AsNoTracking();
            return query;
        }
    }
}
