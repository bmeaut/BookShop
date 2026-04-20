//using BookShop.Transfer.Common;
//using BookShop.Transfer.Dtos.Identity;
//using Microsoft.AspNetCore.Components.Authorization;
//using System.Net.Http.Json;
//using System.Text;

//namespace BookShop.Web.Client.Identity;

//public class AccountService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider) : IAccountService
//{
//    public async Task<IDictionary<string, string[]>?> RegisterAsync(RegisterData registrationData)
//    {
//        var result = await httpClient.PostAsJsonAsync("/register", registrationData);

//        if (result.IsSuccessStatusCode)
//            return null;

//        // Body should contain details about why it failed
//        var validationProblemDetails = await result.Content.ReadFromJsonAsync<ValidationProblemDetails>();
//        return validationProblemDetails?.Errors ?? new Dictionary<string, string[]> { { "Error", ["An unknown error occurred."] } };
//    }

//    public async Task<bool> LoginAsync(LoginData loginData, bool? useCookies, bool? useSessionCookies = false)
//    {
//        var result = await httpClient.PostAsJsonAsync($"/login?useCookies={useCookies}&useSessionCookies={useSessionCookies}", loginData);

//        if (result.IsSuccessStatusCode)
//        {
//            // Refresh authentication state
//            if (authenticationStateProvider is CookieAuthenticationStateProvider cookieAuthProvider) 
//                await cookieAuthProvider.UserStateChanged();
            
//            return true;
//        }

//        return false;
//    }

//    public async Task LogoutAsync()
//    {
//        await httpClient.PostAsync("logout", new StringContent("{}", Encoding.UTF8, "application/json"));

//        // Refresh authentication state
//        if (authenticationStateProvider is CookieAuthenticationStateProvider cookieAuthProvider)
//            await cookieAuthProvider.UserStateChanged();
//    }
//}
