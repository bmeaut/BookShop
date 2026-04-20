using BookShop.Bll.ServicesInterfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.RazorPage.ViewComponents;

public class CategoryListViewComponent(ICategoryService categoryService) : ViewComponent
{
    //public async Task<IViewComponentResult> InvokeAsync() 
    //{ 
    //    return View(await categoryService.GetCategoryTreeAsync()); 
    //}

    public async Task<IViewComponentResult> InvokeAsync(int? categoryId)
    { 
        ViewData["CategoryId"] = categoryId;
        return View(await categoryService.GetCategoryTreeAsync());
    }
}
