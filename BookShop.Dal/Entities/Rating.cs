namespace BookShop.Dal.Entities;

public class Rating
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public int UserId { get; set; }

    public int Value { get; set; }

    public virtual Book Book { get; set; } = null!;
    public virtual ApplicationUser User { get; set; } = null!;
}
