namespace BookShop.Web.Client.StorageAccessor; 

public interface ISessionStorageAccessor
{
    public Task<T?> GetValueAsync<T>(string key);

    public Task SetValueAsync<T>(string key, T value);

    public Task Clear();

    public Task RemoveAsync(string key);
}
