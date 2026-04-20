using BookShop.Transfer.Dtos;

namespace BookShop.Web.Client.Pages.Admin;

public partial class ManageCategories(/*ICategoryClient categoryService*/) 
{
    //public IEnumerable<SelectListItem> AllCategories = [];

    //[BindProperty(SupportsGet = true)]
    //public int? CategoryId { get; set; }

    //[BindProperty]
    //public CreateOrEditCategory Category { get; set; } = new CreateOrEditCategory();

    //public async Task OnGetAsync()
    //{
    //    await LoadModelAsync();

    //    if (CategoryId.HasValue) 
    //        Category = await categoryService.GetCategoryForEditAsync(CategoryId.Value); 
    //}

    //private async Task LoadModelAsync()
    //{
    //    var categoryList = await categoryService.GetCategoryTreeAsync();

    //    // Create list for dropdown, indenting names based on level
    //    AllCategories = categoryList.Select(c => new SelectListItem
    //    {
    //        Text = c.Name.PadLeft(c.Name.Length + c.Level * 2, '\xA0'),
    //        Value = c.Id.ToString()
    //    });
    //}

    //public async Task<IActionResult> OnPostAddOrUpdateAsync()
    //{
    //    if (ModelState.IsValid) 
    //    { 
    //        await categoryService.AddOrUpdateAsync(Category); 
    //        return new RedirectToPageResult("/Admin/ManageCategories"); 
    //    }

    //    // Load the model if any validation error occurs, otherwise the dropdown will be empty and the page will not render correctly
    //    await LoadModelAsync();
    //    return Page(); 
    //}

    //public async Task<IActionResult> OnPostCancelAsync()
    //{
    //    CategoryId = null;

    //    return new RedirectToPageResult("/Admin/ManageCategories");
    //}

    //public async Task<IActionResult> OnPostDeleteAsync() 
    //{ 
    //    if (Category.Id.HasValue) 
    //        await categoryService.DeleteAsync(Category.Id.Value); 
        
    //    return new RedirectToPageResult("/Admin/ManageCategories"); 
    //}
}
