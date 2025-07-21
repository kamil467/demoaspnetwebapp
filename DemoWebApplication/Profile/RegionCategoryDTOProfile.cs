using DemoWebApplication.DTO;
using DemoWebApplication.Model;

namespace DemoWebApplication.Profile;

public class RegionCategoryDTOProfile: AutoMapper.Profile
{
    public RegionCategoryDTOProfile()
    {
        Console.WriteLine("Profile constructor called");
        // convention based 
        // CreateMap<Region, RegionCategoryDTO>();
       // CreateMap<Categories, CategoryDTO>();
       
       // custom mapping
       CreateMap<Region, RegionCategoryDTO>()
           .ForMember(dest => dest.RegionName,
               opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.RegionCity,
               opt => opt.MapFrom(src => src.City))
           .ForMember(dest => dest.RegionCode,
               opt => opt.MapFrom(src => src.Code))
           //.ForMember(dest => dest.RegionEmail,     uncomment to test 
             //  opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.RegionIsActive,
               opt => opt.MapFrom(src => src.IsActive))
           .ForMember(dest => dest.Locale,
               opt => opt.MapFrom(src => src.Locale))
           .ForMember(dest => dest.CategoryDtos,
               opt => opt.MapFrom(src => src.Categories));

            // mapping for categories

            CreateMap<Categories, CategoryDTO>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Description));


    }
}