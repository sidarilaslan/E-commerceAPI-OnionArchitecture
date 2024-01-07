using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(order => order.Id).ValueGeneratedOnAdd();

        builder.HasOne(o => o.CompletedOrder)
         .WithOne(o => o.Order);

        builder.HasOne(o => o.Basket)
            .WithOne(o => o.Order)
            .HasForeignKey<Order>(o => o.BasketId)
              .IsRequired(false);
    }


}