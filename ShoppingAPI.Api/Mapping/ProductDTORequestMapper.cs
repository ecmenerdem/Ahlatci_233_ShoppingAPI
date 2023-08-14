using AutoMapper;
using ShoppingAPI.Entity.DTO.Product;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class ProductDTORequestMapper:Profile
    {
        public ProductDTORequestMapper()
        {
            CreateMap<Product, ProductDTORequest>()
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
               }).ForMember(dest => dest.FeaturedImage,
               opt =>
               {
                   opt.MapFrom(src => src.FeaturedImage);
               }).ReverseMap();
        }
    }
}
