namespace BookShop.Transfer.Dtos;

public class AuthorData : AuthorHeader
{
    public string? PhotoUrl { get; set; }
    public string? About { get; set; }

}
