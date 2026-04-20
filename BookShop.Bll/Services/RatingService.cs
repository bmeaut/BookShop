using BookShop.Bll.ServicesInterfaces;
using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Server.Abstraction.Context;
using BookShop.Transfer.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Bll.Services;

public class RatingService(BookShopDbContext dbContext, IRequestContext requestContext) : IRatingService
{
    private readonly BookShopDbContext dbContext = dbContext;

    public async Task AddRating(RatingData data)
    {
        var rating = new Rating
        {
            BookId = data.BookId,
            UserId = requestContext.UserId!.Value,
            Value = data.Value,
        };

        dbContext.Ratings.Add(rating);
    }
}