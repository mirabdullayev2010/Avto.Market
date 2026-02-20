namespace Avto.Market.Shared.Options;

public class BasePageOption
{
    public bool IsDeleted { get; set; } = false;
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public long? CreatedBy { get; set; }
    public long? UpdatedBy { get; set; }
    public long? DeletedBy { get; set; }
}
