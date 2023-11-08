namespace Ggl.Slst.Db.Domain;

public class GetImgDbQryResult : BaseDbQryResult, IDbQryResult
{
    public string Url { get; init; } = string.Empty;
    public string ThumbnailUrl { get; init; } = string.Empty;
}