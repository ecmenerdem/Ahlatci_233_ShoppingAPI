using FluentValidation;
using ShoppingAPI.Entity.DTO.User;
using System.Data;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class UserRegisterValidation:AbstractValidator<UserRequestDTO>
    {
        public UserRegisterValidation()
        {
            RuleFor(q => q.Adi).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.Soyadi).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullancı Adı Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");

            RuleFor(q => q.EPosta).NotEmpty().WithMessage("E-Posta Boş Olamaz");

            RuleFor(q => q.Tel).NotEmpty().WithMessage("Telefon Boş Olamaz");

            RuleFor(q => q.Adres).NotEmpty().WithMessage("Adres Boş Olamaz");
        }
    }
}
