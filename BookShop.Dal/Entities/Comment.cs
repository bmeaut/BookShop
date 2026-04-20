using BookShop.Transfer.Enums;

namespace BookShop.Dal.Entities;

public class Comment
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }

    public CommentType Type { get; set; }
    public string Text { get; set; } = null!;

    public DateTimeOffset CreatedDate { get; set; }

    public virtual Book Book { get; set; } = null!;
    public virtual ApplicationUser User { get; set; } = null!;
}
