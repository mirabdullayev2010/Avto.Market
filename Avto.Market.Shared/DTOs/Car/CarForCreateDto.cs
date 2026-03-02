namespace Avto.Market.Shared.DTOs.Car;

public class CarForCreateDto
{
    public required string Brend { get; set; }
    public required int Year { get; set; }
    public required decimal Price { get; set; }
    public required string ImagePath { get; set; }
    public required long CategoryId { get; set; }
}
