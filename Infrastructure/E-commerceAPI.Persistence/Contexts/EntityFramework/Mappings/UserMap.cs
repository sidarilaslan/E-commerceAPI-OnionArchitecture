using E_commerceAPI.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerceAPI.Persistence.Contexts.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.Property(user => user.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();

            builder.Property(user => user.FirstName).IsRequired();
            builder.Property(user => user.FirstName).HasMaxLength(100);

            builder.Property(user => user.LastName).IsRequired();
            builder.Property(user => user.LastName).HasMaxLength(100);

            builder.Property(u => u.PhoneNumber).IsRequired(false);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);

            builder.HasMany(u => u.Baskets)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("Users");
        }
    }
}
