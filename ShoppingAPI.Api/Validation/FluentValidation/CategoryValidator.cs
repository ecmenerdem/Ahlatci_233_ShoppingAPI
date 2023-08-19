using FluentValidation;
using ShoppingAPI.Entity.DTO.Category;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class CategoryValidator:AbstractValidator<CategoryDTORequest>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
        }
    }
}
