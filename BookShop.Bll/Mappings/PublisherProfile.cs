using AutoMapper;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;

namespace BookShop.Bll.Mappings;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        CreateMap<Publisher, PublisherHeader>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
