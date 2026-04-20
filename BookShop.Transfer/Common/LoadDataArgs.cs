namespace BookShop.Transfer.Common;

public class LoadDataArgs
{
    /// <summary>
    /// Gets how many items to skip. Related to paging and the current page. Usually used with the <see cref="Enumerable.Skip{TSource}(IEnumerable{TSource}, int)"/> LINQ method.
    /// </summary>
    public int? Skip { get; set; }

    /// <summary>
    /// Gets how many items to take. Related to paging and the current page size. Usually used with the <see cref="Enumerable.Take{TSource}(IEnumerable{TSource}, int)"/> LINQ method.
    /// </summary>
    /// <value>The top.</value>
    public int? Top { get; set; }
}
