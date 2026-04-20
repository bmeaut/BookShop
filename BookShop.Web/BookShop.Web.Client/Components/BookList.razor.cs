using BookShop.Api;
using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;
using BookShop.Web.Client.Models;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Client.Components;

public partial class BookList(IBooksClient booksClient)
{
    private const int DefaultPageSize = 5;
    private const int DefaultCurrentPage = 1;

    [Parameter]
    public RenderFragment<BookData>? ItemTemplate { get; set; }

    [Parameter]
    public int? CategoryId { get; set; }

    [Parameter]
    public BookListType Type { get; set; }

    [Parameter]
    public BookDisplayMode DisplayMode { get; set; }

    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public int Count { get; set; } = 5;

    public IList<BookData> Books { get; private set; } = [];

    [Parameter]
    public bool UsePager { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public int? PageSize { get; set; }

    [Parameter]
    [SupplyParameterFromQuery]
    public int? CurrentPage { get; set; }

    public PagedList<BookData> PagedBooks { get; private set; } = new();

    protected override async Task OnParametersSetAsync()
    {
        if(CurrentPage is null or < 1)
            CurrentPage = DefaultCurrentPage;

        if( PageSize is null or < 1)
            PageSize = DefaultPageSize;

        if (UsePager)
        {
            PagedBooks = CategoryId.HasValue ?
                await booksClient.GetBooksPagedAsync(CategoryId.Value, (CurrentPage - 1) * PageSize, PageSize)
                : new();
        }
        else
        {
            Books = Type switch
            {
                BookListType.Category => CategoryId.HasValue ? await booksClient.GetBooksAsync(CategoryId.Value) : [],
                BookListType.Newest => await booksClient.GetNewestBooksAsync(Count),
                BookListType.Discounted => await booksClient.GetDiscountedBooksAsync(Count),
                _ => [],
            };
        }

        await base.OnParametersSetAsync();
    }
}