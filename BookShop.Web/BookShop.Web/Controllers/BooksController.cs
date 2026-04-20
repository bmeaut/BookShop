using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

public class BooksController(IBookService bookService) : BaseController
{
    /// <summary>
    /// Returns the book with the specified id.
    /// </summary>
    /// <param name="bookId">The id of the book to retrieve.</param>
    /// <returns>The book data.</returns>
    [HttpGet("{bookId:int}")]
    public async Task<BookData> GetBook(int bookId)
        => await bookService.GetBookAsync(bookId);

    /// <summary>
    /// Retrieves the details of a book for editing based on the specified book identifier.
    /// </summary>
    /// <remarks>This method requires the caller to be authorized with the 'Admin' role. If the book with the
    /// specified ID does not exist, an appropriate exception will be thrown.</remarks>
    /// <param name="bookId">The unique identifier of the book to retrieve for editing.</param>
    /// <returns>A CreateOrEditBook object with the book details for editing.</returns>
    [HttpGet("{bookId:int}/edit")]
    [Authorize(Roles = "Admin")]
    public async Task<CreateOrEditBook> GetBookForEdit(int bookId)
        => await bookService.GetBookForEditAsync(bookId);
    
    [HttpGet("{bookId:int}/header")]
    public async Task<BookHeader> GetBookHeader(int bookId)
        => await bookService.GetBookHeaderAsync(bookId);

    [HttpGet("headers")]
    public async Task<IList<BookHeader>> GetBookHeaders([FromQuery] List<int> bookIds)
        => await bookService.GetBookHeadersAsync(bookIds);

    [HttpGet("newest/{count:int}")]
    public async Task<IList<BookData>> GetNewestBooks(int count)
    => await bookService.GetNewestBooksAsync(count);

    [HttpGet("discounted/{count:int}")]
    public async Task<IList<BookData>> GetDiscountedBooks(int count)
        => await bookService.GetDiscountedBooksAsync(count);

    [HttpGet("/categories/{categoryId}/books")]
    public async Task<IList<BookData>> GetBooks(int? categoryId)
        => await bookService.GetBooksAsync(categoryId);

    [HttpGet("/categories/{categoryId}/books/paged")]
    public async Task<PagedList<BookData>> GetBooksPaged(int? categoryId, [FromQuery] LoadDataArgs? args)
        => await bookService.GetBooksPagedAsync(categoryId, args);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<BookData> AddOrUpdate(CreateOrEditBook createOrEditBook)
        => await bookService.AddOrUpdateAsync(createOrEditBook);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task Delete(int id)
        => await bookService.DeleteAsync(id);
}
