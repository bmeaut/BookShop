using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Bll.ServicesInterfaces;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Bll.Services;

public class PublisherService(BookShopDbContext dbContext, IMapper mapper) : IPublisherService
{
    private readonly BookShopDbContext dbContext = dbContext;

    public async Task<IList<PublisherHeader>> GetAllPublishersAsync()
        => await dbContext.Publishers
            .ProjectTo<PublisherHeader>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<PublisherHeader> AddOrUpdateAsync(PublisherHeader data)
    {
        Publisher publisher = null!;

        if (data.Id == 0)
        {
            publisher = new Publisher();
            dbContext.Publishers.Add(publisher);
        }
        else
        {
            publisher = await dbContext.Publishers.SingleAsync(b => b.Id == data.Id);
        }

        publisher.Name = data.Name;

        await dbContext.SaveChangesAsync();

        // Reload data from the database to refresh navigation data too.
        return await ReloadFromDb(publisher.Id);
    }

    public async Task DeleteAsync(int id)
    {
        dbContext.Publishers.Remove(new Publisher { Id = id });

        await dbContext.SaveChangesAsync();
    }

    private async Task<PublisherHeader> ReloadFromDb(int id)
        => await dbContext.Publishers.ProjectTo<PublisherHeader>(mapper.ConfigurationProvider).SingleAsync(x => x.Id == id);
}