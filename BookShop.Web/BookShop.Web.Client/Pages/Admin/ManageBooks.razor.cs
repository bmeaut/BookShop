using BookShop.Api;
using BookShop.Transfer.Dtos;
using BookShop.Transfer.Enums;
using BookShop.Web.Client.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;

namespace BookShop.Web.Client.Pages.Admin;

public partial class ManageBooks(IBooksClient booksClient, ICategoriesClient categoriesClient, IPublishersClient publishersClient,
    NavigationManager navigationManager, IOptions<FileSettings> fileSettingsOptions)
{
    //private readonly IWebHostEnvironment environment = environment;

    public readonly FileSettings FileSettings = fileSettingsOptions.Value;

    [Parameter]
    [SupplyParameterFromQuery]
    public int? BookId { get; set; }

    public CreateOrEditBook Book { get; set; } = new() { PublishYear = DateTime.Now.Year };

    public IBrowserFile? CoverImage { get; set; }

    public string? ErrorMessage { get; set; }

    public IList<CategoryData> AllCategories { get; set; } = [];
    public IList<PublisherHeader> AllPublishers { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        var tasks = new List<Task>()
        {
            Task.Run(async () => AllCategories = await categoriesClient.GetCategoryTreeAsync()),
            Task.Run(async () => AllPublishers = await publishersClient.GetAllPublishersAsync()),
        };

        if (BookId.HasValue)
            tasks.Add(Task.Run( async () => Book = await booksClient.GetBookForEditAsync(BookId.Value)));

        await Task.WhenAll(tasks);

        await base.OnInitializedAsync();
    }

    private void LoadFile(InputFileChangeEventArgs e)
    {
        var ext = Path.GetExtension(CoverImage?.Name)?.ToLowerInvariant();

        if (CoverImage is not null && !FileSettings.PermittedExtensions.Contains(ext ?? ""))
        {
            ErrorMessage = "A file kiterjesztése nem megfelelő.";
            return;
        }

        if (e.File.Size > FileSettings.FileSizeLimit)
        {
            ErrorMessage = "A file mérete meghaladja a megengedett határt.";
            return;
        }

        CoverImage = e.File;
    }

    public async Task UpdateAsync()
    {
        var updatedBook = await booksClient.AddOrUpdateAsync(Book);

        // TODO: Kép feltöltése
        //if (CoverImage?.Length > 0)
        //{
        //    var filePath = Path.Combine(this.environment.WebRootPath, $"images/covers/{updatedBook.Id}{ext}");
        //    using var stream = System.IO.File.Create(filePath);
        //    await CoverImage.CopyToAsync(stream);
        //}

        navigationManager.NavigateTo("/Index");
    }

    public async Task DeleteAsync()
    {
        if (Book?.Id is not null)
            await booksClient.DeleteAsync(Book.Id.Value);

        navigationManager.NavigateTo("/Index");
    }
}
