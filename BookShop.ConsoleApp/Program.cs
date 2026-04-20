using BookShop.Bll;
//using BookShop.ConsoleApp;
//using BookShop.ConsoleApp.Services;
//using BookShop.Server.Abstraction.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Application starting...");

var builder = Host.CreateApplicationBuilder(args);

Console.WriteLine(builder.Environment.EnvironmentName);

// Register BLL services, DbContext and Automapper.
builder.Services.AddBllServices(builder.Configuration);
//builder.Services.AddScoped<IRequestContext, RequestContext>();

//builder.Services.AddScoped<TestMyCode>();

// Host fordítása
var app = builder.Build();

// Létrehozunk egy új scope-ot és abból kérjük le a szükséges osztály példányokat
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<BookShop.Dal.BookShopDbContext>().Database.Migrate();

    // Call code from test service
    //var testMyCodeService = scope.ServiceProvider.GetRequiredService<TestMyCode>();

    //await testMyCodeService.ListBooksAsync();
    //await testMyCodeService.ListCategoriesAsync();
}

await app.RunAsync();