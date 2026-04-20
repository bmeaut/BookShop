using BookShop.Web.Client.Models;
using BookShop.Web.Client.StorageAccessor;

namespace BookShop.Web.Client.Services;

public class CartService(ISessionStorageAccessor sessionStorage) : ICartService
{
    public event EventHandler? OnCartChange;

    private List<CartItem>? cart;

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        cart ??= await sessionStorage.GetValueAsync<List<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        return cart;
    }

    public async Task AddAsync(CartItem cartItem)
    {
        cart ??= await sessionStorage.GetValueAsync<List<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var itemInCart = cart.SingleOrDefault(c => c.BookId == cartItem.BookId);

        if (itemInCart != null)
            itemInCart.Count++;
        else
            cart.Add(cartItem);

        await sessionStorage.SetValueAsync(BookShopConstants.CartSessionKey, cart);

        OnCartChange?.Invoke(this, EventArgs.Empty);
    }

    public async Task RemoveAsync(int bookId)
    {
        cart ??= await sessionStorage.GetValueAsync<List<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var itemInCart = cart.SingleOrDefault(c => c.BookId == bookId);

        if (itemInCart is null)
            return;

        if (itemInCart.Count == 1)
            cart.Remove(itemInCart);
        else
            itemInCart.Count--;

        await sessionStorage.SetValueAsync(BookShopConstants.CartSessionKey, cart);
        OnCartChange?.Invoke(this, EventArgs.Empty);
    }

    public async Task IncrementAsync(int bookId)
    {
        cart ??= await sessionStorage.GetValueAsync<List<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var itemInCart = cart.SingleOrDefault(c => c.BookId == bookId);

        if (itemInCart is null)
            return;

        itemInCart.Count++;

        await sessionStorage.SetValueAsync(BookShopConstants.CartSessionKey, cart);
        OnCartChange?.Invoke(this, EventArgs.Empty);
    }

    public async Task DecrementAsync(int bookId)
    {
        cart ??= await sessionStorage.GetValueAsync<List<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var itemInCart = cart.SingleOrDefault(c => c.BookId == bookId);

        if (itemInCart is null)
            return;

        if (itemInCart.Count == 1)
            cart.Remove(itemInCart);
        else
            itemInCart.Count--;

        await sessionStorage.SetValueAsync(BookShopConstants.CartSessionKey, cart);
        OnCartChange?.Invoke(this, EventArgs.Empty);
    }
}
