using System.Text.Json.Serialization;

namespace BookShop.Transfer.Dtos;

public class CategoryData
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    // TODO: Legyen kötelező
    public string? Order { get; set; }

    [JsonIgnore]
    public int Level { get => Order != null ? Order.Split(".", StringSplitOptions.None).Length : 0; }
}
