using Avto.Market.BLL.Interface.Base;
using Avto.Market.Shared.DTOs.Car;

namespace Avto.Market.BLL.Interface;

public interface ICarService : ICrudService<CarForResultDto, CarForCreateDto, CarForUpdateDto>
{

}
