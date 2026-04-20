using BookShop.Server.Abstraction.Context;
using System.Security.Claims;

namespace BookShop.Web.Services;

public class RequestContext(IHttpContextAccessor httpContextAccessor) : IRequestContext
{
    public string? RequestId { get; }

    public ClaimsIdentity? CurrentUser => httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;

    // public int? UserId => 1;//throw new NotImplementedException();
    public int? UserId => CurrentUser?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value is string userIdStr && int.TryParse(userIdStr, out int userId) ? userId : null;
}
