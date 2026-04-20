using Microsoft.JSInterop;

namespace BookShop.Web.Client.StorageAccessor; 

public class SessionStorageAccessor(IJSRuntime jsRuntime) : ISessionStorageAccessor, IAsyncDisposable
{
    private Lazy<IJSObjectReference> accessorJsRef = new();

    public async Task<T?> GetValueAsync<T>(string key)
    {
        await WaitForReference();

        return await accessorJsRef.Value.InvokeAsync<T?>("get", key);
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await WaitForReference();
        await accessorJsRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task Clear()
    {
        await WaitForReference();
        await accessorJsRef.Value.InvokeVoidAsync("clear");
    }

    public async Task RemoveAsync(string key)
    {
        await WaitForReference();
        await accessorJsRef.Value.InvokeVoidAsync("remove", key);
    }

    private async Task WaitForReference()
    {
        if (accessorJsRef.IsValueCreated is false)
            accessorJsRef = new(await jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/SessionStorageAccessor.js"));
    }

    public async ValueTask DisposeAsync()
    {
        if (accessorJsRef.IsValueCreated)
            await accessorJsRef.Value.DisposeAsync();
    }
}
