namespace BookShop.Transfer.Dtos;

public class OrderData
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public int TotalPrice { get; set; }

    public AddressHeader BillingAddress { get; set; } = null!;
    public AddressHeader ShippingAddress { get; set; } = null!;

    public ICollection<OrderItemData> OrderItems { get; set; } = [];
}
