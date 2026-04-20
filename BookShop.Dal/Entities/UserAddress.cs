using BookShop.Transfer.Enums;

namespace BookShop.Dal.Entities;

public class UserAddress
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int AddressId { get; set; }

    public AddressType Type { get; set; }
    public bool IsDefault { get; set; }

    public virtual Address Address { get; set; } = null!;
    public virtual ApplicationUser User { get; set; } = null!;
}
