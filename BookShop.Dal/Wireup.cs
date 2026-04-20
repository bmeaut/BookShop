using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Dal;

public static class Wireup
{
    public static IServiceCollection AddBookShopDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        // DB Context regisztrálása a DI containerbe.
        services.AddDbContext<BookShopDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
