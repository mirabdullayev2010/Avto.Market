using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Market.Models;

[Table("categories")]
public class Category
{
    [Column("id"), Key]
    public long Id { get; set; }

    [Column("name"), MaxLength(50)]
    public required string Name { get; set; }
    public List<Car>? Cars { get; set; }
}
