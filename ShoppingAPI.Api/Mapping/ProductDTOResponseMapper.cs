using AutoMapper;
using ShoppingAPI.Entity.DTO.Product;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class ProductDTOResponseMapper:Profile
    {
        public ProductDTOResponseMapper()
        {
            CreateMap<Product, ProductDTOResponse>()
               .ForMember(dest => dest.Guid,
               opt =>
               {
                   opt.MapFrom(src => src.Guid);
               }).ForMember(dest => dest.Name,
               opt =>
               {
                   opt.MapFrom(src => src.Name);
               }).ForMember(dest => dest.Description,
               opt =>
               {
                   opt.MapFrom(src => src.Description);
               }).ForMember(dest => dest.CategoryName,
               opt =>
               {
                   opt.MapFrom(src => src.Category.Name);
               }).ForMember(dest => dest.CategoryGUID,
               opt =>
               {
                   opt.MapFrom(src => src.Category.Guid);
               }).ReverseMap();
        }
    }
}
