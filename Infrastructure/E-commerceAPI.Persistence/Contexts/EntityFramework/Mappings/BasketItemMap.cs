using E_commerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.HasKey(bi => bi.Id);
        builder.Property(bi => bi.Id).ValueGeneratedOnAdd();

        builder.ToTable("BasketItems");

    }
}