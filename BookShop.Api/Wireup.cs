using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Api;

public static class Wireup
{
    public const string ApiHttpClientName = "BookShop.Web.Server.Api";

    public static void AddApiClientServices(this IServiceCollection services, Uri baseAddress, Func<DelegatingHandler>? delegatingHandler = null)
    {
        // Configure a named HttpClient with the base address of the API. This client will be used by all API clients to make requests to the API.
        var client = services.AddHttpClient(ApiHttpClientName, client => client.BaseAddress = baseAddress);

        // To allow "ApiHttpClientName" client to be directly injected as an HttpClient instance:
        services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(ApiHttpClientName));

        if (delegatingHandler != null)
            client.AddHttpMessageHandler(delegatingHandler);

        // Register API clients with the DI container, specifying the named HttpClient to use for each client.
        services.AddHttpClient<IBooksClient, BooksClient>(ApiHttpClientName);
        services.AddHttpClient<ICategoriesClient, CategoriesClient>(ApiHttpClientName);
        services.AddHttpClient<ICommentsClient, CommentsClient>(ApiHttpClientName);
        services.AddHttpClient<IPublishersClient, PublishersClient>(ApiHttpClientName);
        services.AddHttpClient<IRatingsClient, RatingsClient>(ApiHttpClientName);
    }
}
