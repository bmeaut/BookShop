using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BookShop.Web.Client.Extensions;

public static class QueryStringExtensions
{
    public static NameValueCollection QueryString(this NavigationManager navigationManager)
        => HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);

    public static string? QueryString(this NavigationManager navigationManager, string key)
        => navigationManager.QueryString()?.Get(key);

    public static Dictionary<string, object?> ToDictionary(this NameValueCollection source)
    {
        return source.Cast<string>()
                     .Select(s => new { Key = s, Value = (object?)source[s] })
                     .ToDictionary(p => p.Key, p => p.Value);
    }
}
