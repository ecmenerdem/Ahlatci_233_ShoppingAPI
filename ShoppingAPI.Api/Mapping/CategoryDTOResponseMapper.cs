using AutoMapper;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class CategoryDTOResponseMapper:Profile
    {
        public CategoryDTOResponseMapper()
        {
            CreateMap<Category, CategoryDTOResponse>()
               .ForMember(dest => dest.Name,
               opt =>
               {
                   opt.MapFrom(src => src.Name);
               }).ReverseMap();
        }
    }
}
