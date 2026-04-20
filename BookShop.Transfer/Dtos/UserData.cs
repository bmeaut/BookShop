namespace BookShop.Transfer.Dtos;

public class UserData : UserHeader
{

    // TODO: Ezekre szükség van?
    public IList<CommentData> Comments { get; set; } = [];
    public IList<RatingData> Ratings { get; set; } = [];

    public IList<AddressHeader> UserAddresses { get; set; } = [];

    public IList<OrderData> Orders { get; set; } = [];
}
