using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

public class CategoriesController(ICategoryService categoryService) : BaseController
{
    [HttpGet]
    public async Task<IList<CategoryData>> GetCategoryTree()
        => await categoryService.GetCategoryTreeAsync();

    [HttpGet("{categoryId}/edit")]
    [Authorize(Roles = "Admin")]
    public async Task<CreateOrEditCategory> GetCategoryForEdit(int categoryId)
        => await categoryService.GetCategoryForEditAsync(categoryId);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<CategoryData> AddOrUpdate(CreateOrEditCategory createOrEditCategory)
        => await categoryService.AddOrUpdateAsync(createOrEditCategory);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task Delete(int id)
        => await categoryService.DeleteAsync(id);
}
