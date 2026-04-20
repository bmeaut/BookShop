using System.ComponentModel.DataAnnotations;

namespace BookShop.Transfer.Dtos;

public class CreateOrEditCategory
{
    public int? Id { get; set; }

    [Required] 
    public string Name { get; set; } = null!;

    [Required]
    public string Order { get; set; } = null!;

    public int? ParentCategoryId { get; set; }
}
