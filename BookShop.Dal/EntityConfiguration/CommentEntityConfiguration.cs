using BookShop.Dal.Entities;
using BookShop.Transfer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);

        // A típus enum értékét stringként tároljuk az adatbázisban, a jobb debuggolhatóság érdekében.
        builder.Property(e => e.Type).HasConversion<string>();

        builder.HasOne(e => e.Book)
            .WithMany(b => b.Comments)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public static void SeedData(EntityTypeBuilder<Comment> builder)
    {
        // Need a user with Id = 1 to run.
        builder.HasData(
            new Comment { Id = 1, BookId = 1, CreatedDate = new DateTimeOffset(2026, 01, 02, 12, 22, 10, new TimeSpan(1, 0, 0)), Type = CommentType.Comment, UserId = 1, Text = "Első komment a könyvhöz." },
            new Comment { Id = 2, BookId = 1, CreatedDate = new DateTimeOffset(2026, 01, 02, 16, 10, 03, new TimeSpan(1, 0, 0)), Type = CommentType.Comment, UserId = 2, Text = "Második komment a könyvhöz." },
            new Comment { Id = 3, BookId = 1, CreatedDate = new DateTimeOffset(2026, 01, 03, 08, 47, 24, new TimeSpan(1, 0, 0)), Type = CommentType.Review, UserId = 1, Text = "Első review a könyvhöz." },
            new Comment { Id = 4, BookId = 1, CreatedDate = new DateTimeOffset(2026, 01, 03, 17, 33, 54, new TimeSpan(1, 0, 0)), Type = CommentType.Review, UserId = 2, Text = "Második review a könyvhöz." }
        );
    }
}