using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using BookShop.Web.RazorPage.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace BookShop.Web.RazorPage.Pages.Admin;

public class ManageBooksModel(IBookService bookService, ICategoryService categoryService, IPublisherService publisherService,
    IOptions<FileSettings> fileSettingsOptions, IWebHostEnvironment environment) : PageModel
{
    private readonly IBookService bookService = bookService;
    private readonly ICategoryService categoryService = categoryService;
    private readonly IPublisherService publisherService = publisherService;
    private readonly IWebHostEnvironment environment = environment;

    // Must be public to be able to access from cshtml.
    public readonly FileSettings FileSettings = fileSettingsOptions.Value;

    [BindProperty(SupportsGet = true)]
    public int? BookId { get; set; }

    [BindProperty]
    public CreateOrEditBook Book { get; set; } = new() { PublishYear = DateTime.Now.Year };

    [BindProperty]
    public IFormFile? CoverImage { get; set; }

    public IEnumerable<SelectListItem> AllCategories { get; set; } = [];
    public IEnumerable<SelectListItem> AllPublishers { get; set; } = [];

    public async Task OnGetAsync()
    {
        await LoadModelAsync();

        if (BookId.HasValue)
            Book = await bookService.GetBookForEditAsync(BookId.Value);
    }

    public async Task<IActionResult> OnPostAddOrUpdateAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadModelAsync();
            return Page();
        }

        var ext = Path.GetExtension(CoverImage?.FileName)?.ToLowerInvariant();

        if (CoverImage is not null && !FileSettings.PermittedExtensions.Contains(ext ?? ""))
        {
            // Add validation error if the file extension is not permitted.
            ModelState.AddModelError("CoverImage", "A kép kiterjesztése nem megfelelő.");

            await LoadModelAsync();
            return Page();
        }

        var updatedBook = await bookService.AddOrUpdateAsync(Book);

        if (CoverImage?.Length > 0)
        {
            var filePath = Path.Combine(this.environment.WebRootPath, $"images/covers/{updatedBook.Id}{ext}");
            using var stream = System.IO.File.Create(filePath);
            await CoverImage.CopyToAsync(stream);
        }

        return new RedirectToPageResult("/Index");
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        if (Book?.Id is not null)
            await bookService.DeleteAsync(Book.Id.Value);

        return new RedirectToPageResult("/Index");
    }

    private async Task LoadModelAsync()
    {
        var categoryList = await categoryService.GetCategoryTreeAsync();

        AllCategories = categoryList.Select(c => new SelectListItem
        {
            Text = c.Name.PadLeft(c.Name.Length + (c.Level - 1) * 3, '\xA0'),
            Value = c.Id.ToString()
        });

        AllPublishers = (await publisherService.GetAllPublishersAsync()).Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });
    }
}
