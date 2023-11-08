namespace Ggl.Slst.Db.Abstractions;

public abstract class BaseDbQry
{
    public long Id { get; init; }
    public long UsrId { get; init; }
    public long OffsetId { get; init; }
    public int OffsetBoundry { get; init; }
    public int Limit { get; init; }
    public string QueryString { get; init; } = string.Empty;
}
