using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace BookShop.Web.Client.Handler;

public class IncludeRequestCredentialsHttpMessageHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // To include cookies, we need to set the credentials to include for each request
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        request.Headers.Add("X-Requested-With", ["XMLHttpRequest"]);

        return base.SendAsync(request, cancellationToken);
    }
}