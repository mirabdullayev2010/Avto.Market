using System;
using System.Collections.Generic;
using System.Text;

namespace Avto.Market.Shared.Options.Cars;

public class CarForPageOption : BasePageOption
{
    public long? CarId { get; set; }
    public string? Brend { get; set; }
    public int? Year { get; set; }
    public long? CategoryId { get; set; }
}
