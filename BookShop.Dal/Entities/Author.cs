namespace BookShop.Dal.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string? About { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = [];
}
