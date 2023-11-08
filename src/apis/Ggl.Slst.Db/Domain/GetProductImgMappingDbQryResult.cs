namespace Ggl.Slst.Db.Domain;

public class GetProductImgMappingDbQryResult: BaseDbQryResult, IDbQryResult
{
    public long ImgId { get; init; }
    public string Url { get; init; } = string.Empty;
    public string ThumbnailUrl { get; init; } = string.Empty;
}