using BookShop.Bll.Mappings;
using BookShop.Bll.Services;
using BookShop.Bll.ServicesInterfaces;
using BookShop.Dal;
using BookShop.Transfer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Bll;

public static class Wireup
{
    public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DB Context regisztrálása a DI containerbe.
        services.AddBookShopDbContext(configuration);

        services.RegisterValidators();

        // AutoMapper regisztrálása a DI containerbe.
        services.AddAutoMapper(
                cfg =>
                {
                    cfg.LicenseKey = configuration.GetRequiredSection("AutoMapper").GetValue<string>("LicenseKey");
                }, typeof(BookProfile));

        // Register Bll Servies
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IRatingService, RatingService>();

        return services;
    }
}
