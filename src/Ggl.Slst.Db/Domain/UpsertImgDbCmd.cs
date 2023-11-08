namespace Ggl.Slst.Db.Domain;

public class UpsertImgDbCmd : BaseDbCmd, IDbCmd
{
    public string Url { get; init; } = string.Empty;
    public string ThumbnailUrl { get; init; } = string.Empty;
}