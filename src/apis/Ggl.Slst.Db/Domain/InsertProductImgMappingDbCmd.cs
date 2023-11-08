namespace Ggl.Slst.Db.Domain;

public class InsertProductImgMappingDbCmd : BaseDbCmd, IDbCmd
{
    public long ProductId { get; init; }
    public long ImgId { get; init; }
}