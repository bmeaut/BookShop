namespace BookShop.Dal.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int? CategoryId { get; set; }
    public int? PublisherId { get; set; }
    public string? Subtitle { get; set; }
    public string? ShortDescription { get; set; }
    public int Price { get; set; }
    public int? DiscountedPrice { get; set; }
    public int PublishYear { get; set; }
    public int PageNumber { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public int SumRating { get; set; }
    public int RatingCount { get; set; }

    public virtual Category? Category { get; set; }
    public virtual Publisher Publisher { get; set; } = null!;
    public virtual ICollection<Comment> Comments { get; set; } = [];
    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = [];
    public virtual ICollection<Rating> Ratings { get; set; } = [];
}
