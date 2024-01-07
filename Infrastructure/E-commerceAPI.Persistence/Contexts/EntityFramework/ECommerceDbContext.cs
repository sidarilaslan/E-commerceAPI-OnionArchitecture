using E_commerceAPI.Domain.Entities;
using E_commerceAPI.Domain.Entities.Common;
using E_commerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_commerceAPI.Persistence.Contexts.EntityFramework
{
    public class ECommerceDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ECommerceDbContext()
        {

        }
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Modified)
                    entry.Entity.ModifiedDate = DateTime.UtcNow;
                else if (entry.State == EntityState.Added)
                    entry.Entity.CreatedDate = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
