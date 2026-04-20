using AutoMapper;
using BookShop.Dal.Entities;
using BookShop.Transfer.Dtos;

namespace BookShop.Bll.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateProjection<Category, CategoryData>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId))
            .ForMember(dest => dest.Level, opt => opt.Ignore());    // Level is a read only calculated property, do not map.

        CreateProjection<Category, CreateOrEditCategory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId));
    }
}
