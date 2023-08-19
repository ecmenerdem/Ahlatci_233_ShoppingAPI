using AutoMapper;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class CategoryDTORequestMapper:Profile
    {
        public CategoryDTORequestMapper()
        {
            CreateMap<Category,CategoryDTORequest>()
                .ForMember(dest => dest.Name,
                opt =>
                {
                    opt.MapFrom(src => src.Name);
                }).ReverseMap();
        }
    }
}
