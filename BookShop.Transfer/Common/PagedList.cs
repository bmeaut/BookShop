namespace BookShop.Transfer.Common;

public class PagedList<T>
{
    public int TotalItems { get; set; }

    public IList<T> Items { get; set; } = [];
}
