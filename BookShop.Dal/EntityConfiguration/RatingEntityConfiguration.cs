using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class RatingEntityConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Book)
            .WithMany(b => b.Ratings)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public static void SeedData(EntityTypeBuilder<Rating> builder)
    { 
    }
}