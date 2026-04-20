using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

public class PublishersController(IPublisherService publisherService) : BaseController
{
    [HttpGet]
    public async Task<IList<PublisherHeader>> GetAllPublishers()
        => await publisherService.GetAllPublishersAsync();

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<PublisherHeader> AddOrUpdate(PublisherHeader data)
        => await publisherService.AddOrUpdateAsync(data);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task Delete(int id)
        => await publisherService.DeleteAsync(id);
}
