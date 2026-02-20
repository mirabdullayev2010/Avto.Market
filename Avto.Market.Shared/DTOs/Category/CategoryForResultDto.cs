using Avto.Market.Shared.DTOs.Car;

namespace Auto.Market.DTOs.Category;

public class CategoryForResultDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public List<CarForResultDto>? Cars { get; set; }
}
