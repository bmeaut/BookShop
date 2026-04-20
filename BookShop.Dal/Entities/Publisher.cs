namespace BookShop.Dal.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = [];
}
