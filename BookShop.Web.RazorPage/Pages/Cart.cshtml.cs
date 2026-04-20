using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using BookShop.Web.RazorPage.Extensions;
using BookShop.Web.RazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.RazorPage.Pages;

[Authorize]
public class CartModel(IBookService bookService) : PageModel
{
    public IList<CartItem> Cart { get; set; } = null!;
    public IList<BookHeader> Books { get; set; } = [];

    public async Task OnGet() 
    { 
        Cart = HttpContext.Session.Get<IList<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var bookIds = Cart.Select(ci => ci.BookId).ToList();
        Books = await bookService.GetBookHeadersAsync(bookIds) ?? [];
    }

    public IActionResult OnPostDecrement(int bookId)
    {
        var cart = HttpContext.Session.Get<IList<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var cartItem = cart.Single(c => c.BookId == bookId);

        if (cartItem.Count == 1)
            cart.Remove(cartItem);
        else
            cartItem.Count--;

        HttpContext.Session.Set(BookShopConstants.CartSessionKey, cart);

        return new RedirectToPageResult("Cart");
    }

    public IActionResult OnPostIncrement(int bookId)
    {
        var cart = HttpContext.Session.Get<IList<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var cartItem = cart.Single(c => c.BookId == bookId);
        cartItem.Count++;

        HttpContext.Session.Set(BookShopConstants.CartSessionKey, cart);

        return new RedirectToPageResult("Cart");
    }

    public IActionResult OnPostRemoveFromCart(int bookId)
    {
        var cart = HttpContext.Session.Get<IList<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var cartItem = cart.Single(c => c.BookId == bookId);
        cart.Remove(cartItem);

        HttpContext.Session.Set(BookShopConstants.CartSessionKey, cart);

        return new RedirectToPageResult("Cart");
    }
}
