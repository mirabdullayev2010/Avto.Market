namespace Avto.Market.Shared.DTOs.Car;

public class CarForUpdateDto
{
    public required string Brend { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public long CategoryId { get; set; }
    public CarForResultDto? Category { get; set; }
}
