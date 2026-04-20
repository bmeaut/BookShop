using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookShop.Dal;
internal class BookShopDbContextFactory : IDesignTimeDbContextFactory<BookShopDbContext>
{
    public BookShopDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookShopDbContext>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookShopDb2;Integrated Security=True;TrustServerCertificate=True");

        return new BookShopDbContext(optionsBuilder.Options);
    }
}
