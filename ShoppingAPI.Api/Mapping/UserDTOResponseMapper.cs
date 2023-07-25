using AutoMapper;
using ShoppingAPI.Entity.DTO.User;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class UserDTOResponseMapper:Profile
    {
        public UserDTOResponseMapper()
        {
            CreateMap<User, UserResponseDTO>()
                .ForMember(dest => dest.Adi, opt =>
                {
                    opt.MapFrom(src => src.FirstName);
                })
                .ForMember(dest => dest.Soyadi, opt =>
                {
                    opt.MapFrom(src => src.LastName);
                })
                .ForMember(dest => dest.KullaniciAdi, opt =>
                {
                    opt.MapFrom(src => src.UserName);
                })
                .ForMember(dest => dest.Sifre, opt =>
                {
                    opt.MapFrom(src => src.Password);
                })
                .ForMember(dest => dest.EPosta, opt =>
                {
                    opt.MapFrom(src => src.Email);
                })
                .ForMember(dest => dest.Tel, opt =>
                {
                    opt.MapFrom(src => src.Phone);
                })
                .ForMember(dest => dest.Adres, opt =>
                {
                    opt.MapFrom(src => src.Adress);
                }).ReverseMap();
        }

    }
}
