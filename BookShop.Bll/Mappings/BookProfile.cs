using AutoMapper;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;

namespace BookShop.Bll.Mappings;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookHeader>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Subtitle, opt => opt.MapFrom(src => src.Subtitle))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.DiscountedPrice))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(x => x.Author)))
            .IncludeAllDerived();   // Derived classes using this mapping too.

        CreateMap<Book, BookData>()
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => src.PublishYear))
            .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
            .ForMember(dest => dest.SumRating, opt => opt.MapFrom(src => src.SumRating))
            .ForMember(dest => dest.NumberOfRatings, opt => opt.MapFrom(src => src.RatingCount))
            .ForMember(dest => dest.NumberOfComments, opt => opt.MapFrom(src => src.Comments.Count()))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.PublisherId))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
            .ForMember(dest => dest.AverageRating, opt => opt.Ignore());

        CreateMap<Book, CreateOrEditBook>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Subtitle, opt => opt.MapFrom(src => src.Subtitle))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.DiscountedPrice))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(x => x.Author)))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.PublishYear, opt => opt.MapFrom(src => src.PublishYear))
            .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.PublisherId));
    }
}
