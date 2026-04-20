using BookShop.Transfer.Dtos.Identity;
using BookShop.Web.Client.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Text.Json;

namespace BookShop.Web.Client.Pages;

public partial class Login(IAccountService accountManager, NavigationManager navigationManager)
{
    public bool LoginFailed { get; set; } = false;
    public LoginData LoginData { get; set; } = new() { Email = "", Password = "" };

    [Parameter]
    [SupplyParameterFromQuery]
    public string? ReturnUrl { get; set; }

    private async Task HandleLogin()
    {
        var result = await accountManager.LoginAsync(LoginData, true);
        
        if( !result)
        {
            LoginFailed = true;
            return;
        }

        // We use NavigateToLogin so the return url is stored in the history state.
        var returnUrl = "/";
        if (!String.IsNullOrEmpty(navigationManager.HistoryEntryState))
            returnUrl = JsonSerializer.Deserialize<InteractiveRequestOptions>(navigationManager.HistoryEntryState)?.ReturnUrl ?? "/";

        navigationManager.NavigateTo(returnUrl ?? "/");
    }
}