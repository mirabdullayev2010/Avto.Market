using Auto.Market.DTOs.Category;
using FluentValidation.Results;
namespace Avto.Market.BLL.Validations.Interface;

public interface ICategoryValidatorService
{
    Task<ValidationResult> CreateValidator(CategoryForCreateDto dto);
    Task<ValidationResult> UpdateValidator(CategoryForUpdateDto dto);
}
