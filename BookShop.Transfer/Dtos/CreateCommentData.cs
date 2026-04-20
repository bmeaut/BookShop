using BookShop.Transfer.Enums;

namespace BookShop.Transfer.Dtos;

public class CreateCommentData
{
    public int BookId { get; set; }

    public CommentType Type { get; set; }

    public string Text { get; set; } = null!;
}
