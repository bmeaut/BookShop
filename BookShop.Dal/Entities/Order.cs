namespace BookShop.Dal.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public int BillingAddressId { get; set; }
    public int ShippingAddressId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int TotalPrice { get; set; }

    public ApplicationUser User { get; set; } = null!;
    public Address BillingAddress { get; set; } = null!;
    public Address ShippingAddress { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
