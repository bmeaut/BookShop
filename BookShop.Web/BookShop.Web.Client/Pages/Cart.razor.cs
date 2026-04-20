using BookShop.Api;
using BookShop.Transfer.Dtos;
using BookShop.Web.Client.Models;
using BookShop.Web.Client.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookShop.Web.Client.Pages;

[Authorize]
public partial class Cart(ICartService cartService, IBooksClient booksClient)
{
    public List<CartItem> CartItems { get; set; } = [];

    public IList<BookHeader> Books { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        CartItems = await cartService.GetCartItemsAsync();

        var bookIds = CartItems.Select(ci => ci.BookId).ToList();
        Books = await booksClient.GetBookHeadersAsync(bookIds) ?? [];

        await base.OnInitializedAsync();
    }
}