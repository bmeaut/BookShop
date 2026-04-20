using BookShop.Transfer.Enums;

namespace BookShop.Transfer.Dtos;

public class CommentData
{
    public int Id { get; set; }

    public CommentType Type { get; set; }

    public string Text { get; set; } = null!;

    public string UserDisplayName { get; set; } = null!;

    public DateTimeOffset CreatedDate { get; set; }

    public BookHeader BookHeader { get; set; } = null!;
}

