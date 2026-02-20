using Avto.Market.Shared.DTOs.Car;

namespace Auto.Market.DTOs.Category;

public class CategoryForUpdateDto
{
    public required string Name { get; set; }
    public List<CarForResultDto>? Cars { get; set; }
}
