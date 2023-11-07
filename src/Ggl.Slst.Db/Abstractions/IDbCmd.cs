namespace Ggl.Slst.Db.Abstractions;

public interface IDbCmd
{
    long Id { get; init; }
    long UserId { get; init; }
    IDbCmdResult Result { get; set; }
}
