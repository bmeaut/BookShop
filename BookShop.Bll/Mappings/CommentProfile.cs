using AutoMapper;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;

namespace BookShop.Bll.Mappings;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateProjection<Comment, CommentData>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserDisplayName, opt => opt.MapFrom(src => src.User.DisplayName))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.BookHeader, opt => opt.MapFrom(src => src.Book));
    }
}
