namespace BookShop.Transfer.Dtos;

public class OrderItemData
{
    public int Id { get; set; }

    public int Price { get; set; }
    public int? DiscountedPrice { get; set; }
    public int Quantity { get; set; }

    public BookHeader Book { get; set; } = null!;
}
