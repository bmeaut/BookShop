using BookShop.Transfer.Dtos.Identity;
using BookShop.Web.Client.Identity;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Client.Pages;

public partial class Register(IAccountService accountManager, NavigationManager navigationManager)
{
    // public bool RegisterFailed { get; set; } = false;
    public string[] Errors { get; set; } = [];
    public RegisterData RegisterData { get; set; } = new();

    private async Task HandleRegister()
    {
        var errorResult = await accountManager.RegisterAsync(RegisterData);
        
        if(errorResult?.Any() == true)
        {
            // RegisterFailed = true;
            Errors = errorResult.SelectMany(x => x.Value).ToArray();
            return;
        }
        
        navigationManager.NavigateTo("/");
    }
}