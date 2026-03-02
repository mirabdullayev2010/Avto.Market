

using Auto.Market.DTOs.Category;
using Avto.Market.BLL.Interface.Base;

namespace Avto.Market.BLL.Interface
{
    public interface ICategoryService : ICrudService<CategoryForResultDto, CategoryForCreateDto, CategoryForUpdateDto>
    {
    }
}
