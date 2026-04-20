using BookShop.Web.Client.Identity;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookShop.Web.Client.Pages;

public partial class Logout(IAccountService accountManager, AuthenticationStateProvider authenticationStateProvider)
{
    protected override async Task OnInitializedAsync()
    {
        var state = await authenticationStateProvider.GetAuthenticationStateAsync();

        if( state.User.Identity?.IsAuthenticated == true)
        {
            await accountManager.LogoutAsync();
        }
    }
}