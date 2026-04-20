using BookShop.Transfer.Dtos;

namespace BookShop.Bll.ServicesInterfaces;

public interface ICategoryService
{
    Task<IList<CategoryData>> GetCategoryTreeAsync();

    Task<CreateOrEditCategory> GetCategoryForEditAsync(int categoryId);

    Task<CategoryData> AddOrUpdateAsync(CreateOrEditCategory createOrEditCategory);

    Task DeleteAsync(int id);
}
