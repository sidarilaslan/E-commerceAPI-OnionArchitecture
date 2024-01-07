using E_commerceAPI.Persistence.Contexts.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace E_commerceAPI.Persistence.Contexts;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
{
    public ECommerceDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ECommerceDbContext> contextOptionsBuilder = new();
        contextOptionsBuilder.UseSqlServer(ConnectionStringConfiguration.GetLocalMssqlServerConnectionString());
        return new(contextOptionsBuilder.Options);
    }
}