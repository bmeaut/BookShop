using System.ComponentModel.DataAnnotations;

namespace BookShop.Transfer.Dtos;

public class CreateOrEditBook
{
    public int? Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }
    
    [Required]
    public int? Price { get; set; }

    public int? DiscountedPrice { get; set; }

    public List<AuthorHeader> Authors { get; set; } = [];

    public string? ShortDescription { get; set; }

    [Required]
    public int? PublishYear { get; set; }

    [Required]
    public int? PageNumber { get; set; }

    [Required]
    public int? CategoryId { get; set; }

    [Required]
    public int? PublisherId { get; set; }
}
