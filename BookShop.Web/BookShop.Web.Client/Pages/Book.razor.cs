using BookShop.Api;
using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;
using BookShop.Web.Client.Models;
using BookShop.Web.Client.Services;
// using BookShop.Web.Client.StorageAccessor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BookShop.Web.Client.Pages;

public partial class Book(IBooksClient booksClient, ICommentsClient commentsClient, ICartService cartService, NavigationManager navigationManager /*, ISessionStorageAccessor sessionStorage*/)
{
    [Parameter]
    public int Id { get; set; }

    public BookData BookData { get; set; } = new();

    public IList<CommentData> Comments { get; set; } = [];
    public IList<CommentData> Reviews { get; set; } = [];

    public CreateCommentData NewCommentData { get; set; } = null!;

    protected override void OnInitialized()
    {
        NewCommentData = new CreateCommentData() { BookId = Id, Type = CommentType.Comment };

        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        var tasks = new Task[]
        {
            Task.Run(async () => BookData = await booksClient.GetBookAsync(Id)),
            Task.Run(async () => Comments = await commentsClient.GetCommentsAsync(Id, CommentType.Comment, 5)),
            Task.Run(async () => Reviews = await commentsClient.GetCommentsAsync(Id, CommentType.Review, 2)),
        };

        await Task.WhenAll(tasks);

        // BookData = await booksClient.GetBookAsync(Id);
        // Comments = await commentsClient.GetCommentsAsync(Id, Transfer.Enums.CommentType.Comment, 5);

        await base.OnInitializedAsync();
    }

    protected void ToLogin()
    {
        InteractiveRequestOptions requestOptions = new()
        {
            Interaction = InteractionType.SignIn,
            ReturnUrl = navigationManager.Uri,
        };

        navigationManager.NavigateToLogin("/login", requestOptions);
    }

    public async Task AddToCart()
    {
        await cartService.AddAsync(new CartItem
        {
            BookId = BookData.Id,
            Count = 1,
            Price = BookData.DiscountedPrice ?? BookData.Price
        });
    }

    public async Task CreateComment()
    {
        await commentsClient.CreateCommentAsync(NewCommentData);

        NewCommentData.Text = string.Empty;
        Comments = await commentsClient.GetCommentsAsync(Id, CommentType.Comment, 5);
    }
}