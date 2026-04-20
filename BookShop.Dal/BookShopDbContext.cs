using BookShop.Dal.Entities;
using BookShop.Dal.EntityConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Dal;

public class BookShopDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(options)
{
    // Define DbSet properties for each entity in the model.
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Create Identity configurations for Identity tables
        base.OnModelCreating(modelBuilder);

        // Apply configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookShopDbContext).Assembly);

        // Seed initial data
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed in the proper order.
        AuthorEntityConfiguration.SeedData(modelBuilder.Entity<Author>());
        CategoryEntityConfiguration.SeedData(modelBuilder.Entity<Category>());
        PublisherEntityConfiguration.SeedData(modelBuilder.Entity<Publisher>());

        BookEntityConfiguration.SeedData(modelBuilder.Entity<Book>());

        BookAuthorEntityConfiguration.SeedData(modelBuilder.Entity<BookAuthor>());
        
        AddressEntityConfiguration.SeedData(modelBuilder.Entity<Address>());

        ApplicationUserEntityConfiguration.SeedData(modelBuilder);

        OrderEntityConfiguration.SeedData(modelBuilder.Entity<Order>());
        OrderItemEntityConfiguration.SeedData(modelBuilder.Entity<OrderItem>());

        CommentEntityConfiguration.SeedData(modelBuilder.Entity<Comment>());
        RatingEntityConfiguration.SeedData(modelBuilder.Entity<Rating>());
        UserAddressEntityConfiguration.SeedData(modelBuilder.Entity<UserAddress>());
    }
}
