using Avto.Market.Shared.DTOs.Car;
using FluentValidation;

namespace Avto.Market.BLL.Validations.Car;

public class CarForUpdateValidation : AbstractValidator<CarForUpdateDto>
{
    public CarForUpdateValidation()
    {
        RuleFor(x => x.Brend)
            .NotEmpty().WithMessage("Brendni kiritish shart")
            .MaximumLength(100).WithMessage("Brend 100 ta belgidan oshmasligi kere");
        RuleFor(x => x.Year)
            .NotEmpty().WithMessage("Yilni kiriting")
            .InclusiveBetween(1886, DateTime.Now.Year).WithMessage($"Yil 1886 va orasida bolishi kere {DateTime.Now.Year}.");
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Narkni kiriting")
            .GreaterThan(0).WithMessage("Narx 0 dan katta bolishi kere");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId kiriting");
    }
}
