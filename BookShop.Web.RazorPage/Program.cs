using BookShop.Bll;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Server.Abstraction.Context;
using BookShop.Web.RazorPage.Services;
using BookShop.Web.RazorPage.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

#region // Use Default Identity

//builder.Services.AddDefaultIdentity<ApplicationUser>()
//    .AddRoles<IdentityRole<int>>()
//    .AddEntityFrameworkStores<BookShopDbContext>();

#endregion

#region // Use Identity Core

//builder.Services.AddIdentityCore<ApplicationUser>()
//    .AddRoles<IdentityRole<int>>()
//    .AddSignInManager()
//    .AddEntityFrameworkStores<BookShopDbContext>();

//builder.Services.AddAuthentication()
//    .AddCookie(IdentityConstants.ExternalScheme, o =>
//    {
//        o.Cookie.Name = IdentityConstants.ExternalScheme;
//        o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//    });

// builder.Services.TryAddTransient<IEmailSender, NoOpEmailSender>();

#endregion

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(
   options =>
   {
       options.SignIn.RequireConfirmedAccount = true;
       // Password settings.
       options.Password.RequiredLength = 12;
       options.Password.RequireNonAlphanumeric = true;
       options.Password.RequireUppercase = true;
       options.Password.RequireLowercase = true;
       options.Password.RequireDigit = true;

       options.Password.RequiredUniqueChars = 6;

       // Lockout settings.
       options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
       options.Lockout.MaxFailedAccessAttempts = 5;
       options.Lockout.AllowedForNewUsers = true;

       // User settings.
       options.User.RequireUniqueEmail = true;
       options.User.AllowedUserNameCharacters =
       "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

       // Sign‑in (only for production scenarios, for development you might want to disable these).
       // options.SignIn.RequireConfirmedAccount = true;
       // options.SignIn.RequireConfirmedEmail = true;
   })
   .AddEntityFrameworkStores<BookShopDbContext>()
   .AddDefaultTokenProviders();

builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
{
    options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"] ?? throw new InvalidOperationException("Microsoft ClientId not found in configuration.");
    options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"] ?? throw new InvalidOperationException("Microsoft ClientSecret not found in configuration.");
});

// builder.Services.TryAddTransient<IEmailSender, NoOpEmailSender>();
builder.Services.TryAddTransient<IEmailSender, EmailSender>();

// Reads the email settings from the configuration and registers it in the DI container.
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EMailSettings"));
builder.Services.Configure<FileSettings>(builder.Configuration.GetSection("FileSettings"));

// builder.Services.AddIdentityApiEndpoints<ApplicationUser>()

// Register Services to DI.
builder.Services.AddBllServices(builder.Configuration);
builder.Services.AddScoped<IRequestContext, RequestContext>();

// Add services to the container.
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin", "RequireAdminRole");
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".IdentityNet10.Auth";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax; // or Strict for pure server‑rendered sites
    
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequiredLength = 12;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;

    options.Password.RequiredUniqueChars = 6;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

    // Sign‑in (only for production scenarios, for development you might want to disable these).
    // options.SignIn.RequireConfirmedAccount = true;
    // options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    // options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Processes requests to execute migrations operations.
    app.UseMigrationsEndPoint();
}
else
{ 
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

// app.MapIdentityApi<ApplicationUser>();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
