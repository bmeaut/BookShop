using BookShop.Transfer.Common;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Bll.Helpers;

public static class PagedListHelper
{
    public static async Task<PagedList<TQuery>> ToPagedListAsync<TQuery>(this IQueryable<TQuery> source, int? skip, int? top)
    {
        var totalItems = await source.CountAsync();

        if (top is not null)
            source = source.Skip(skip ?? 0).Take(top.Value);

        return new PagedList<TQuery>
        {
            Items = await source.ToListAsync(),
            TotalItems = totalItems
        };
    }
}
