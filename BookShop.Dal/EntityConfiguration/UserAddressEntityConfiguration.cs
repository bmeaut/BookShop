using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class UserAddressEntityConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Type).HasConversion<string>();

        builder.HasOne(e => e.User)
            .WithMany(u => u.UserAddresses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Address)
            .WithMany(a => a.UserAddresses)
            .HasForeignKey(e => e.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public static void SeedData(EntityTypeBuilder<UserAddress> builder)
    { 
    }
}