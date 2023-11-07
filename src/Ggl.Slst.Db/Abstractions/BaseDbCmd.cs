namespace Ggl.Slst.Db.Abstractions;

public abstract class BaseDbCmd
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public IDbCmdResult Result { get; set; } = new EmptyCmdResult();
}
