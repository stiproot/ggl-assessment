namespace Ggl.Slst.Db.Abstractions;

public interface IDbQryResult
{
    long Id { get; init; }
    Guid Guid { get; init; }
    long UserId { get; init; }
    DateTime CreationTimestampUtc { get; init; }
}
