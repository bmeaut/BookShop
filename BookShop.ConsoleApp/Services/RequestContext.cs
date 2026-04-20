using BookShop.Server.Abstraction.Context;
using System.Security.Claims;

namespace BookShop.ConsoleApp.Services;

public class RequestContext : IRequestContext
{
    public string? RequestId { get; }

    public ClaimsIdentity? CurrentUser { get; }

    public int? UserId => 1;//throw new NotImplementedException();
}
