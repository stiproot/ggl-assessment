namespace Ggl.Slst.Db.Abstractions;

public interface IDbQryResult
{
    long Id { get; init; }
    long UsrId { get; init; }
    DateTime CreationTimestampUtc { get; init; }
}
