using BookShop.Web.Client.Models;

namespace BookShop.Web.Client.Services;

public interface ICartService
{
    public event EventHandler OnCartChange;

    public Task<List<CartItem>> GetCartItemsAsync();

    public Task AddAsync(CartItem cartItem);

    public Task RemoveAsync(int bookId);

    public Task IncrementAsync(int bookId);

    public Task DecrementAsync(int bookId);
}
