using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.HasMany(b => b.BasketItems)
            .WithOne(b => b.Basket)
            .HasForeignKey(b => b.BasketId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(b => b.Order)
        //    .WithOne(b => b.Basket)
        //    .HasForeignKey<Basket>(b => b.OrderId);

        builder.ToTable("Baskets");

    }
}