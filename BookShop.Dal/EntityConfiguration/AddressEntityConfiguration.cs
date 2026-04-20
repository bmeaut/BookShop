using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.City).HasMaxLength(50);
        builder.Property(e => e.ZipCode).HasMaxLength(10);
        builder.Property(e => e.Street).HasMaxLength(100);
    }

    public static void SeedData(EntityTypeBuilder<Address> builder)
    {
        builder.HasData(
            new Address { Id = 1, ZipCode = "1111", City = "Budapest", Street = "Magyar Tudósok krt. 2. Q. épület" },
            new Address { Id = 2, ZipCode = "1111", City = "Budapest", Street = "Magyar Tudósok krt. 2. I. épület" }
        );
    }
}
