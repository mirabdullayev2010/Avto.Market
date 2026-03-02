
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Market.Models;

[Table("cars")]
public class Car
{
    [Column("image_path")]
    public required string ImagePath { get; set; }

    [Column("id"), Key]
    public long Id { get; set; }

    [Column("brend")]
    public required string Brend { get; set; }

    [Column("year")]
    public required int Year { get; set; }

    [Column("price")]
    public required decimal Price { get; set; }

    public long CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

}
