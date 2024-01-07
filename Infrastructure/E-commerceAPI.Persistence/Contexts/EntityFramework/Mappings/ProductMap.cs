using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerceAPI.Persistence.Contexts.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Description).HasMaxLength(5000);
            builder.Property(p => p.Code).HasMaxLength(50);
            builder.Property(p => p.Color).HasMaxLength(50);


            builder.HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.BasketItems)
                .WithOne(b => b.Product)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ProductImageFiles)
                .WithMany(b => b.Products);


            builder.ToTable("Products");
        }
    }
}
