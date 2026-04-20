namespace BookShop.Dal.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public string Order { get; set; } = null!;
    
    public virtual Category? ParentCategory { get; set; }
    public virtual ICollection<Book> Books { get; set; } = [];
    public virtual ICollection<Category> ChildCategories { get; set; } = [];
}
