using Auto.Market.DTOs.Category;
using FluentValidation;

namespace Avto.Market.BLL.Validations.Category;

public class CategoryForUpdateValidator : AbstractValidator<CategoryForUpdateDto>
{
    public CategoryForUpdateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category nomini kiritish shart")
            .MaximumLength(100).WithMessage("Category nomi 100 ta belgidan oshmasligi kere");
    }
}
