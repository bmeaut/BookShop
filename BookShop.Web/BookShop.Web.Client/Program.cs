using BookShop.Api;
using BookShop.Transfer;
using BookShop.Web.Client.Handler;
using BookShop.Web.Client.Identity;
using BookShop.Web.Client.Services;
using BookShop.Web.Client.Settings;
using BookShop.Web.Client.StorageAccessor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.RegisterValidators();

builder.Services.AddApiClientServices(new Uri(builder.HostEnvironment.BaseAddress), () => new IncludeRequestCredentialsHttpMessageHandler());

builder.Services.AddSingleton<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(sp => (IAccountService)sp.GetRequiredService<AuthenticationStateProvider>());

// builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSingleton<ISessionStorageAccessor, SessionStorageAccessor>();
builder.Services.AddSingleton<ICartService, CartService>();

builder.Services.Configure<FileSettings>(builder.Configuration.GetSection("FileSettings"));

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

await builder.Build().RunAsync();
