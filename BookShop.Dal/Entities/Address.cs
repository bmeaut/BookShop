namespace BookShop.Dal.Entities;

public class Address
{
    public int Id { get; set; }
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Street { get; set; } = null!;

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = [];
}
