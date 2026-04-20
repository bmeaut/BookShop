using BookShop.Transfer.Dtos;

namespace BookShop.Bll.ServicesInterfaces;

public interface IPublisherService
{
    Task<IList<PublisherHeader>> GetAllPublishersAsync();

    Task<PublisherHeader> AddOrUpdateAsync(PublisherHeader data);
    Task DeleteAsync(int id);
}