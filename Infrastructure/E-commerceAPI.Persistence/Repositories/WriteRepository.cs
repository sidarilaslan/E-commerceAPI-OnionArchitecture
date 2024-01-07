using E_commerceAPI.Application.Repositories;
using E_commerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_commerceAPI.Persistence.Repositories
{
    public class WriteRepository<T, TContext> : IWriteRepository<T> where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public WriteRepository(TContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entites)
        {
            await Table.AddRangeAsync(entites);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FindAsync(Guid.Parse(id));
            return Remove(entity);
        }

        public bool RemoveRange(List<T> entites)
        {
            Table.RemoveRange(entites);
            return true;
        }

        public async Task<int> SaveAsync()
         => await _context.SaveChangesAsync();


        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
