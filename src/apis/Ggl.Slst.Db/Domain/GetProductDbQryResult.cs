namespace Ggl.Slst.Db.Domain;

public class GetProductDbQryResult : BaseDbQryResult, IDbQryResult
{
    public string Code { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}