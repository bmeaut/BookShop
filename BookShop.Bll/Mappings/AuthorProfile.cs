using AutoMapper;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;

namespace BookShop.Bll.Mappings;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorHeader>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .IncludeAllDerived();

        CreateMap<Author, AuthorData>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
            .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.About));
    }
}
