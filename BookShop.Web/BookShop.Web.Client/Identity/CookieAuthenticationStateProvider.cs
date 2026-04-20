using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos.Identity;
using BookShop.Web.Client.Identity.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Data;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace BookShop.Web.Client.Identity;

/// <summary>
/// Handles state for cookie-based authentication.
/// </summary>
public class CookieAuthenticationStateProvider(IHttpClientFactory httpClientFactory, ILogger<CookieAuthenticationStateProvider> logger)
    : AuthenticationStateProvider, IAccountService
{
    /// <summary>
    /// Map the JavaScript-formatted properties to C#-formatted classes.
    /// </summary>
    private static readonly JsonSerializerOptions jsonSerializerOptions = new() 
    { 
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    private readonly HttpClient httpClient = httpClientFactory.CreateClient(Api.Wireup.ApiHttpClientName);

    private readonly ClaimsPrincipal unAuthenticatedUser = new(new ClaimsIdentity());

    /// <summary>
    /// Get authentication state.
    /// </summary>
    /// <remarks>
    /// Called by Blazor anytime and authentication-based decision needs to be made, then cached
    /// until the changed state notification is raised.
    /// </remarks>
    /// <returns>The authentication state asynchronous request.</returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Default to not authenticated
        var user = unAuthenticatedUser;

        try
        {
            // The user info endpoint is secured, so if the user isn't logged in this will fail
            using var userResponse = await httpClient.GetAsync("manage/info");
            userResponse.EnsureSuccessStatusCode();

            // User is authenticated, so let's build their authenticated identity
            var userInfo = await userResponse.Content.ReadFromJsonAsync<UserInfo>(jsonSerializerOptions);

            if (userInfo != null)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, userInfo.Email),
                    new(ClaimTypes.Email, userInfo.Email),
                };

                // Add any additional claims
                claims.AddRange(
                    userInfo.Claims.Where(c => c.Key != ClaimTypes.Name && c.Key != ClaimTypes.Email)
                        .Select(c => new Claim(c.Key, c.Value)));


                // Request the roles endpoint for the user's roles
                using var rolesResponse = await httpClient.GetAsync("roles");
                rolesResponse.EnsureSuccessStatusCode();
                var roleClaims = await rolesResponse.Content.ReadFromJsonAsync<RoleClaim[]>(jsonSerializerOptions);

                // Add any roles to the claims collection
                if (roleClaims?.Length > 0)
                {
                    claims.AddRange(roleClaims
                        .Where(x => !string.IsNullOrEmpty(x.Type) && !string.IsNullOrEmpty(x.Value))
                        .Select(x => new Claim(x.Type!, x.Value!, x.ValueType, x.Issuer, x.OriginalIssuer))
                    );
                }

                // Set the principal
                var identity = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
                user = new ClaimsPrincipal(identity);
            }
        }
        catch (Exception ex) when (ex is HttpRequestException exception)
        {
            if (exception.StatusCode != HttpStatusCode.Unauthorized)
            {
                logger.LogError(ex, "App error");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "App error");
        }

        return new AuthenticationState(user);
    }

    public async Task<bool> LoginAsync(LoginData loginData, bool? useCookies, bool? useSessionCookies = false)
    {
        var result = await httpClient.PostAsJsonAsync($"/login?useCookies={useCookies}&useSessionCookies={useSessionCookies}", loginData);

        if (result.IsSuccessStatusCode)
        {
            // Refresh authentication state
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return true;
        }

        return false;
    }

    public async Task LogoutAsync()
    {
        await httpClient.PostAsync("logout", new StringContent("{}", Encoding.UTF8, "application/json"));

        // Refresh authentication state
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task<IDictionary<string, string[]>?> RegisterAsync(RegisterData registrationData)
    {
        var result = await httpClient.PostAsJsonAsync("/register", registrationData);

        if (result.IsSuccessStatusCode)
            return null;

        // Body should contain details about why it failed
        var validationProblemDetails = await result.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        return validationProblemDetails?.Errors ?? new Dictionary<string, string[]> { { "Error", ["An unknown error occurred."] } };
    }

    // public async Task UserStateChanged()
    //    => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}