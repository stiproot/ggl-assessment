namespace Ggl.Slst.Db.Domain;

public class GetLstDbQryResult : BaseDbQryResult, IDbQryResult
{
    public IEnumerable<long> ProductIds { get; init; } = new List<long>();
    public string Name { get; init; } = string.Empty;
}