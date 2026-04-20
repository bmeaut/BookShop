using BookShop.Transfer.Enums;

namespace BookShop.Transfer.Dtos;

public class AddressHeader
{
    public int Id { get; set; }
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Street { get; set; } = null!;

    public AddressType AddressType { get; set; }
}
