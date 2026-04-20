using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Bll.ServicesInterfaces;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Bll.Services;

public class CategoryService(BookShopDbContext dbContext, IMapper mapper) : ICategoryService
{
    private readonly BookShopDbContext dbContext = dbContext;

    public async Task<IList<CategoryData>> GetCategoryTreeAsync()
    {
        var allCategories = await dbContext.Categories
            .OrderBy(c => c.Order)
            .ProjectTo<CategoryData>(mapper.ConfigurationProvider)
            .ToListAsync();

        return allCategories;
    }

    public async Task<CreateOrEditCategory> GetCategoryForEditAsync(int categoryId) 
        => await dbContext.Categories
            .ProjectTo<CreateOrEditCategory>(mapper.ConfigurationProvider)
            .SingleAsync(c => c.Id == categoryId); 

    public async Task<CategoryData> AddOrUpdateAsync(CreateOrEditCategory createOrEditCategory)
    {
        Category category = null!;

        if (createOrEditCategory.Id is null)
        {
            category = new Category();
            dbContext.Categories.Add(category);
        }
        else
        {
            category = dbContext.Categories.Single(c => c.Id == createOrEditCategory.Id);
        }

        category.Name = createOrEditCategory.Name;
        category.Order = createOrEditCategory.Order;
        category.ParentCategoryId = createOrEditCategory.ParentCategoryId;

        await dbContext.SaveChangesAsync();

        return await ReloadFromDb(category.Id);
    }

    public async Task DeleteAsync(int id)
    {
        // Do not load the entity from the database just to delete it
        // var category = DbContext.Categories.Single(c => c.Id == categoryId);
        // DbContext.Categories.Remove(category);

        dbContext.Categories.Remove(new Category { Id = id });

        await dbContext.SaveChangesAsync();
    }

    private async Task<CategoryData> ReloadFromDb(int id)
        => await dbContext.Categories.ProjectTo<CategoryData>(mapper.ConfigurationProvider).SingleAsync(x => x.Id == id);
}