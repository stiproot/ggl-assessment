namespace Ggl.Slst.Db.Abstractions;

public abstract class BaseDbQryResult
{
    public long Id { get; init; } = -1;
    public long UsrId { get; init; } = -1;
    public DateTime CreationTimestampUtc { get; init; } = DateTime.UtcNow;
}
