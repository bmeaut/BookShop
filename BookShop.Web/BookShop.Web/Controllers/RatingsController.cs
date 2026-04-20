using BookShop.Bll.ServicesInterfaces;
using BookShop.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers;

public class RatingsController(IRatingService ratingService) : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task AddRating(RatingData data)
        => await ratingService.AddRating(data);
}
