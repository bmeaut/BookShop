using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;
using BookShop.Web.RazorPage.Extensions;
using BookShop.Web.RazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.RazorPage.Pages;
public class BookModel(IBookService bookService, ICommentService commentService) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public BookData Book { get; set; } = null!;

    public IList<CommentData> Comments { get; set; } = [];
    public IList<CommentData> Reviews{ get; set; } = [];

    [BindProperty]
    public CreateCommentData NewComment { get; set; } = null!;

    public async Task OnGetAsync()
    {
        // Query the book details
        Book = await bookService.GetBookAsync(Id);

        Comments = await commentService.GetCommentsAsync(Id, CommentType.Comment);
        Reviews = await commentService.GetCommentsAsync(Id, CommentType.Review, 2);

        NewComment = new CreateCommentData() { BookId = Id };
    }

    public async Task<IActionResult> OnPostAddToCartAsync(int bookId) 
    {
        if(User.Identity?.IsAuthenticated != true)
            return Unauthorized();

        var cart = HttpContext.Session.Get<List<CartItem>>(BookShopConstants.CartSessionKey) ?? [];

        var book = await bookService.GetBookAsync(bookId);

        var cartItem = cart.SingleOrDefault(c => c.BookId == book.Id);

        if (cartItem != null)
        {
            cartItem.Count++;
        }
        else
        {
            cartItem = new CartItem 
            { 
                BookId = book.Id, 
                Count = 1, 
                Price = book.DiscountedPrice ?? book.Price 
            };

            cart.Add(cartItem);
        }

        HttpContext.Session.Set(BookShopConstants.CartSessionKey, cart);

        return new RedirectToPageResult("/Book", new { id = book.Id });
    }

    public async Task<IActionResult> OnPostCreateCommentAsync()
    {
        if (User.Identity?.IsAuthenticated != true)
            return Unauthorized();

        // Set the Type to comment, otherwise it remains 0 and stored in the DB as 0, not Comment.
        NewComment.Type = CommentType.Comment;

        if (!ModelState.IsValid)
        {
            Book = await bookService.GetBookAsync(NewComment.BookId);

            return Page();
        }

        await commentService.CreateCommentAsync(NewComment); 

        return RedirectToPage("/Book", new { Id = NewComment.BookId }); 
    }
}
