namespace Ggl.Slst.Db.Domain;

public class UpsertProductDbCmd : BaseDbCmd, IDbCmd
{
    public string Code { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}