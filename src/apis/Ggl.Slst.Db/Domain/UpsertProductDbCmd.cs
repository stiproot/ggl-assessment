namespace Ggl.Slst.Db.Domain;

public class UpsertProductDbCmd : BaseDbCmd, IDbCmd
{
    public string Code { get; init; } = string.Empty;
    public string Desc { get; init; } = string.Empty;
}