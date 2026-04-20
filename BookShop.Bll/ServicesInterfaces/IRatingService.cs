using BookShop.Transfer.Dtos;

namespace BookShop.Bll.ServicesInterfaces;

public interface IRatingService
{
    Task AddRating(RatingData data);
}