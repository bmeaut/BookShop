using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Book)
            .WithMany()
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public static void SeedData(EntityTypeBuilder<OrderItem> builder)
    { 
    }
}