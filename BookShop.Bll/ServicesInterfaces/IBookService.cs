using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos;

namespace BookShop.Bll.ServicesInterfaces;

public interface IBookService
{
    Task<BookData> GetBookAsync(int bookId);

    Task<CreateOrEditBook> GetBookForEditAsync(int bookId);

    Task<BookHeader> GetBookHeaderAsync(int bookId);

    Task<IList<BookHeader>> GetBookHeadersAsync(List<int> bookIds);

    Task<IList<BookData>> GetBooksAsync(int? categoryId);

    Task<PagedList<BookData>> GetBooksPagedAsync(int? categoryId, LoadDataArgs? args);

    Task<IList<BookData>> GetNewestBooksAsync(int count);

    Task<IList<BookData>> GetDiscountedBooksAsync(int count);

    Task<BookData> AddOrUpdateAsync(CreateOrEditBook bookData);

    Task DeleteAsync(int bookId);
}
