using System.Security.Claims;

namespace BookShop.Server.Abstraction.Context;

/// <summary>
/// Gets the request's sender's request's identifier and user information.
/// </summary>
public interface IRequestContext
{
    string? RequestId { get; }

    ClaimsIdentity? CurrentUser { get; }

    public int? UserId { get; }
}