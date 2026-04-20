using System.Text.Json;

namespace BookShop.Api;

public class BaseClient
{
    protected static void UpdateJsonSerializerSettings(JsonSerializerOptions options)
    {
        options ??= new() { WriteIndented = true };
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.ReadCommentHandling = JsonCommentHandling.Skip;
    }
}
