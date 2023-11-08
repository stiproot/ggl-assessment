namespace Ggl.Slst.Db.Domain;

public class GetProductImgMappingDbQry: BaseDbQry, IDbQry
{
    public long ProductId { get; init; }
}