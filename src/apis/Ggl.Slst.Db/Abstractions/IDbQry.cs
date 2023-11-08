namespace Ggl.Slst.Db.Abstractions;

public interface IDbQry
{
    long Id { get; init; }
    long UsrId { get; init; }
    long OffsetId { get; init; }
    int OffsetBoundry { get; init; }
    int Limit { get; init; }
    string QueryString { get; init; }
}
