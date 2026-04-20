using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.RazorPage.Pages;

public class IndexModel(IBookService bookService) : PageModel
{
    public IList<BookData> NewestBooks { get; set; } = [];
    public IList<BookData> DiscountedBooks { get; set; } = [];
    // public IList<BookData> Books { get; private set; } = [];

    public PagedList<BookData> PagedBooks { get; private set; } = new();

    public int PageSize { get; set; } = 10;

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int? CategoryId { get; set; }

    public async Task OnGet()
    {
        // Query book data from the BLL service
        NewestBooks = await bookService.GetNewestBooksAsync(5);
        DiscountedBooks = await bookService.GetDiscountedBooksAsync(5);
        // Books = await bookService.GetBooksAsync(CategoryId);

        PagedBooks = await bookService.GetBooksPagedAsync(CategoryId, new LoadDataArgs { Skip = (CurrentPage - 1) * PageSize, Top = PageSize });
    }
}