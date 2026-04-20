using BookShop.Api;
using BookShop.Transfer.Dtos;

namespace BookShop.Web.Client.Components;

public partial class CategoryList(ICategoriesClient categoriesClient)
{
    public IList<CategoryData> Categories { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Categories = await categoriesClient.GetCategoryTreeAsync();

        await base.OnInitializedAsync();
    }
}