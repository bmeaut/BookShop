using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Bll.Helpers;
using BookShop.Bll.ServicesInterfaces;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Transfer.Common;
using BookShop.Transfer.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Bll.Services;

public class BookService(BookShopDbContext dbContext, IMapper mapper) : IBookService
{
    private readonly BookShopDbContext dbContext = dbContext;

    /// <summary>
    /// Returns the book with the given ID.
    /// </summary>
    /// <returns></returns>
    public async Task<BookData> GetBookAsync(int bookId)
    {
        var book = await dbContext.Books
            .Where(x => x.Id == bookId)
            .ProjectTo<BookData>(mapper.ConfigurationProvider)
            .SingleAsync();

        return book;
    }

    public async Task<CreateOrEditBook> GetBookForEditAsync(int bookId)
    {
        var book = await dbContext.Books
            .Where(x => x.Id == bookId)
            .ProjectTo<CreateOrEditBook>(mapper.ConfigurationProvider)
            .SingleAsync();

        return book;
    }
    

    public async Task<BookHeader> GetBookHeaderAsync(int bookId)
        => await dbContext.Books
            .Where(x => x.Id == bookId)
            .ProjectTo<BookHeader>(mapper.ConfigurationProvider)
            .SingleAsync();

    public async Task<IList<BookHeader>> GetBookHeadersAsync(List<int> bookIds)
        => await dbContext.Books
            .Where(x => bookIds.Contains(x.Id))
            .ProjectTo<BookHeader>(mapper.ConfigurationProvider)
            .ToListAsync();

    /// <summary>
    /// Returns all books ordered by their title.
    /// </summary>
    /// <param name="categoryId">Selected category ID, if any.</param>
    /// <returns></returns>
    public async Task<IList<BookData>> GetBooksAsync(int? categoryId)
    {
        // Note: this category filtering logic assumes only two-level category hierarchy (categories and their direct subcategories).
        var books = await dbContext.Books
            .Where(x => !categoryId.HasValue || x.CategoryId == categoryId.Value || x.Category!.ParentCategoryId == categoryId.Value)
            .OrderBy(x => x.Title)
            .ProjectTo<BookData>(mapper.ConfigurationProvider)
            .ToListAsync();

        return books;
    }

    /// <summary>
    /// Returns books paged, optionally filtered by category.
    /// </summary>
    /// <param name="categoryId">Selected category ID, if any.</param>
    /// <param name="args">Paging parameters.</param>
    /// <returns></returns>
    public async Task<PagedList<BookData>> GetBooksPagedAsync(int? categoryId, LoadDataArgs? args)
    {
        // Note: this category filtering logic assumes only two-level category hierarchy (categories and their direct subcategories).
        var books = await dbContext.Books
            .Where(x => !categoryId.HasValue || x.CategoryId == categoryId.Value || x.Category!.ParentCategoryId == categoryId.Value)
            .OrderBy(x => x.Title)
            .ProjectTo<BookData>(mapper.ConfigurationProvider)
            .ToPagedListAsync(args?.Skip, args?.Top);

        return books;
    }

    /// <summary>
    /// Returns the newest books based on their CreatedDate.
    /// </summary>
    /// <param name="count">The maximum number of newest books to return.</param>
    /// <returns></returns>
    public async Task<IList<BookData>> GetNewestBooksAsync(int count)
    {
        var books = await dbContext.Books
            .OrderByDescending(x => x.CreatedDate)
            .ProjectTo<BookData>(mapper.ConfigurationProvider)
            .Take(count)
            .ToListAsync();

        return books;
    }

    /// <summary>
    /// Returns books that have a discounted price.
    /// </summary>
    /// <param name="count">The maximum number of discounted books to return.</param>
    public async Task<IList<BookData>> GetDiscountedBooksAsync(int count)
    {
        var books = await dbContext.Books
            .Where(x => x.DiscountedPrice.HasValue)
            .ProjectTo<BookData>(mapper.ConfigurationProvider)
            .Take(count)
            .ToListAsync();

        return books;
    }

    public async Task<BookData> AddOrUpdateAsync(CreateOrEditBook createOrEditBook)
    {
        Book book = null!;

        if (createOrEditBook.Id is null)
        {
            book = new Book { CreatedDate = DateTime.Now };
            dbContext.Books.Add(book);
        }
        else
        {
            book = await dbContext.Books.SingleAsync(b => b.Id == createOrEditBook.Id);
        }

        book.Title = createOrEditBook.Title;
        book.Subtitle = createOrEditBook.Subtitle;
        book.ShortDescription = createOrEditBook.ShortDescription;

        // These fields has required validation, so we can safely use the ! operator to get their values.
        book.PageNumber = createOrEditBook.PageNumber!.Value;
        book.PublishYear = createOrEditBook.PublishYear!.Value;
        book.Price = createOrEditBook.Price!.Value;
        book.DiscountedPrice = createOrEditBook.DiscountedPrice;

        book.CategoryId = createOrEditBook.CategoryId;
        book.PublisherId = createOrEditBook.PublisherId;

        // TODO: Hogyan lehet majd megadni
        // BookAuthors = ,

        await dbContext.SaveChangesAsync();

        // Reload data from the database to refresh navigation data too.
        return await ReloadFromDb(book.Id);
    }

    public async Task DeleteAsync(int id)
    {
        dbContext.Books.Remove(new Book { Id = id });

        await dbContext.SaveChangesAsync();
    }

    private async Task<BookData> ReloadFromDb(int id)
        => await dbContext.Books.ProjectTo<BookData>(mapper.ConfigurationProvider).SingleAsync(x => x.Id == id);
}