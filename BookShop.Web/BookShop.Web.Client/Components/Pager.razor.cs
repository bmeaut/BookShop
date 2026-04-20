using BookShop.Web.Client.Extensions;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Client.Components;

public partial class Pager(NavigationManager navigationManager)
{
    [Parameter]
    public int TotalItems { get; set; }

    [Parameter]
    public int CurrentPage { get; set; }

    [Parameter]
    public int PageSize { get; set; }

    [Parameter]
    public int PagesToShow { get; set; } = 3;

    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)TotalItems / PageSize) : 0;

    private Dictionary<string, object?> allRouteData = [];

    protected override void OnParametersSet()
    {
        // Read the query string parameters into a dictionary, to be able to construct navigation links with all query string data.
        allRouteData = navigationManager.QueryString().ToDictionary();
    }

    public string ToPage(int pageNumber)
    {
        allRouteData[nameof(CurrentPage)] = pageNumber.ToString();
        return navigationManager.GetUriWithQueryParameters(allRouteData);
    }
}