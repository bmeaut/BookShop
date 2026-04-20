using BookShop.Transfer.Dtos.Identity;

namespace BookShop.Web.Client.Identity;

public interface IAccountService
{
    public Task<bool> LoginAsync(LoginData loginData, bool? useCookies, bool? useSessionCookies = true);

    public Task LogoutAsync();

    public Task<IDictionary<string, string[]>?> RegisterAsync(RegisterData registrationData);
}
