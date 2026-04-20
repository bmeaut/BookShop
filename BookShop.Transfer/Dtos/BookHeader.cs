namespace BookShop.Transfer.Dtos;

public class BookHeader
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public string? Subtitle { get; set; }

    public int Price { get; set; }
    public int? DiscountedPrice { get; set; }

    public List<AuthorHeader> Authors { get; set; } = [];
}
