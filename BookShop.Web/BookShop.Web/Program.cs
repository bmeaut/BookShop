using BookShop.Bll;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Server.Abstraction.Context;
using BookShop.Web.Components;
using BookShop.Web.Services;
using BookShop.Web.Settings;
using BookShop.Web.ValidationFilter;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scalar.AspNetCore;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
   .AddRoles<IdentityRole<int>>()
   .AddEntityFrameworkStores<BookShopDbContext>()
   .AddDefaultTokenProviders();

// Only cookie authentication.
//builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

//builder.Services.AddIdentityCore<ApplicationUser>()
//    .AddRoles<IdentityRole<int>>()
//    .AddEntityFrameworkStores<BookShopDbContext>()
//    .AddApiEndpoints();

// MS Authentication
//builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
//{
//    options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"] ?? throw new InvalidOperationException("Microsoft ClientId not found in configuration.");
//    options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"] ?? throw new InvalidOperationException("Microsoft ClientSecret not found in configuration.");
//});

// builder.Services.AddAuthorizationBuilder();

//// Add services to the container.
//builder.Services.AddAuthorizationBuilder()
//    .AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

// Reads the email settings from the configuration and registers it in the DI container.
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
//builder.Services.Configure<FileSettings>(builder.Configuration.GetSection("FileSettings"));

builder.Services.TryAddSingleton<IEmailSender<ApplicationUser>, EmailSender<ApplicationUser>>();
builder.Services.Configure<FileSettings>(builder.Configuration.GetSection("FileSettings"));

builder.Services.AddEndpointsApiExplorer();

// Need for NSwag generation.
builder.Services.AddOpenApiDocument();

builder.Services.AddOpenApi();

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization(options => options.SerializeAllClaims = true);

// Register Bll and Dal Servces.
builder.Services.AddBllServices(builder.Configuration);

// Register additional non-BLL services.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRequestContext, RequestContext>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // Do not serialize null values.
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// builder.Services.AddMvc();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ModelValidationAsyncActionFilter));
});

// TODO: írni róla
//builder.Services.AddAntiforgery(options =>
//{
//    options.SuppressXFrameOptionsHeader = false;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//});

// builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.UseWebAssemblyDebugging();
}
else if (builder.Environment.IsEnvironment("SwaggerGenerator"))
{
    // Note: Handle NSwag generation error: System.InvalidOperationException: The static resources manifest file
    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name ?? "";
    //Log.Warning("Replacing ApplicationName with AssemblyTitle: {EnvironmentApplicationName} -> {assemblyName}",
    //    builder.Environment.ApplicationName, assemblyName);

    builder.Environment.ApplicationName = assemblyName;
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.MapIdentityApi<ApplicationUser>();

app.UseAuthentication();
app.UseAuthorization();

// Provide an endpoint to clear the cookie for logout
// For more information on the logout endpoint and antiforgery, see:
// https://learn.microsoft.com/aspnet/core/blazor/security/webassembly/standalone-with-identity#antiforgery-support
app.MapPost("/logout", async (SignInManager<ApplicationUser> signInManager, [FromBody] object empty) =>
{
    if (empty is not null)
    {
        await signInManager.SignOutAsync();

        return Results.Ok();
    }

    return Results.Unauthorized();
}).RequireAuthorization();

// Provide an endpoint for user roles
app.MapGet("/roles", (ClaimsPrincipal user) =>
{
    if (user.Identity is not null && user.Identity.IsAuthenticated)
    {
        var identity = (ClaimsIdentity)user.Identity;
        // Note: Claim cannot be serialized by default, so we create an anonymous object with the relevant properties to return as JSON.
        var roles = identity.FindAll(identity.RoleClaimType)
                        .Select(c => new { c.Issuer, c.OriginalIssuer, c.Type, c.Value, c.ValueType });

        return TypedResults.Json(roles);
    }

    return Results.Unauthorized();
}).RequireAuthorization();

//app.MapIdentityApi<ApplicationUser>().AddOpenApiOperationTransformer(async (operation, context, _) =>
//{
//    // Transform /login endpoint to document the ProblemHttpResult 401 response which is
//    // not included by default. See: https://github.com/dotnet/aspnetcore/issues/52424
//    if (context.Description is { HttpMethod: "POST", RelativePath: "login" })
//    {
//        operation.Responses ??= new OpenApiResponses();
//        operation.Responses.TryAdd("401", new OpenApiResponse
//        {
//            Description = "Unauthorized",
//            Content = new Dictionary<string, OpenApiMediaType>
//            {
//                ["application/problem+json"] = new()
//                {
//                    Schema = new OpenApiSchemaReference("ProblemDetails", context.Document)
//                }
//            }
//        });
//    }
//});

app.UseAntiforgery();

app.MapControllers();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BookShop.Web.Client._Imports).Assembly);

app.Run();
