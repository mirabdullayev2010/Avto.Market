using System.ComponentModel.DataAnnotations;

namespace Auto.Market.DTOs.Category;

public class CategoryForCreateDto
{
    [MaxLength(50)]
    public required string Name { get; set; }
}
