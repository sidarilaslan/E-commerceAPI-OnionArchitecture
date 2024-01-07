using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerceAPI.Persistence.Contexts.EntityFramework.Mappings
{
    public class EndPointMap : IEntityTypeConfiguration<Endpoint>
    {
        public void Configure(EntityTypeBuilder<Endpoint> builder)
        {
            builder.HasMany(e => e.Roles)
            .WithMany(u => u.Endpoints);
        }
    }

}
