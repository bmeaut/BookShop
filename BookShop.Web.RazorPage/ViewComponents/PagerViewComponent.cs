using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.RazorPage.ViewComponents;

public class PagerViewComponent : ViewComponent
{
    public class PagerArgs
    { 
        public int TotalItems { get; set; } 
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int PagesToShow { get; set; } = 3;
    }

    public IViewComponentResult Invoke(int pageSize, int currentPage, int totalItems, int pagesToShow) 
    { 
        return View(new PagerArgs 
        { 
            PageSize = pageSize, 
            CurrentPage = currentPage,
            TotalItems = totalItems, 
            TotalPages = (int)Math.Ceiling((double)totalItems / (double)pageSize), 
            PagesToShow = pagesToShow 
        }); 
    }
}
