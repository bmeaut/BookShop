using System.Text.Json.Serialization;

namespace BookShop.Transfer.Dtos;

public class BookData : BookHeader
{
    public string? ShortDescription { get; set; }

    public int PublishYear { get; set; }
    public int PageNumber { get; set; }

    public int NumberOfComments { get; set; }
    public int NumberOfRatings { get; set; }

    public int SumRating { get; set; }

    [JsonIgnore]
    public decimal? AverageRating 
    { 
        get => NumberOfRatings > 0 ? ((decimal)SumRating / NumberOfRatings) : null; 
    }

    public int? CategoryId { get; set; }
    public int? PublisherId { get; set; }

    public PublisherHeader? Publisher { get; set; }
}
