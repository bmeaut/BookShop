using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BookShop.Transfer.Dtos;

namespace BookShop.Transfer;

public static class Wireup
{
    public static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        // Register all fluent validator as singleton from the current project (also internal classes).
        services.AddValidatorsFromAssemblyContaining<LogirRequestDataValidator>(ServiceLifetime.Singleton, includeInternalTypes: true);

        return services;
    }
}
