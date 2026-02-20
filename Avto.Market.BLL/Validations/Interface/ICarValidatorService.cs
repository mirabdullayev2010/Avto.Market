using Avto.Market.Shared.DTOs.Car;
using FluentValidation.Results;

namespace Avto.Market.BLL.Validations.Interface;

public interface ICarValidatorService
{
    Task<ValidationResult> CreateValidator(CarForCreateDto dto);
    Task<ValidationResult> UpdateValidator(CarForUpdateDto dto);
}
