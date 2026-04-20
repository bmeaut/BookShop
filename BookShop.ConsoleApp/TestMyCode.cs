using BookShop.Bll.ServicesInterfaces;

namespace BookShop.ConsoleApp;

public class TestMyCode(IBookService bookService, ICategoryService categoryService)
{
    public async Task ListBooksAsync()
    {
        var books = await bookService.GetBooksAsync(null);

        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id}: {book.Title} - {string.Join(", ", book.Authors)} ({book.PublishYear})");
        }
    }

    public async Task ListCategoriesAsync()
    {
        var categories = await categoryService.GetCategoryTreeAsync();

        foreach (var category in categories)
        {
            Console.WriteLine($"{new string(' ', (category.Level - 1) * 2)}- {category.Name} (Level: {category.Level})");
        }
    }
}
