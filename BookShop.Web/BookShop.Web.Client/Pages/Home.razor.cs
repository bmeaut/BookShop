using BookShop.Api;
using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Client.Pages;

public partial class Home(/*IBooksClient booksClient*/)
{
    [Parameter]
    public int? CategoryId { get; set; }

    //[Parameter]
    //[SupplyParameterFromQuery]
    //public int? PageSize { get; set; }

    //[Parameter]
    //[SupplyParameterFromQuery]
    //public int? CurrentPage { get; set; }

    // public IList<BookData> NewestBooks { get; set; } = [];
    // public IList<BookData> DiscountedBooks { get; private set; } = [];
    // public IList<BookData> Books { get; private set; } = [];

    //protected override async Task OnInitializedAsync()
    //{
    //    // Query book data from the server
    //    NewestBooks = await booksClient.GetNewestBooksAsync(5);
    //    DiscountedBooks = await booksClient.GetDiscountedBooksAsync(5);
    //    Books = await booksClient.GetBooksAsync(CategoryId ?? 1);
    //}

    //protected override async Task OnParametersSetAsync()
    //{
    //    Books = await booksClient.GetBooksAsync(CategoryId ?? 1);

    //    await base.OnParametersSetAsync();
    //}
}