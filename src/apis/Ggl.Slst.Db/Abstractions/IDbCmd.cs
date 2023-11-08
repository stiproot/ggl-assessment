namespace Ggl.Slst.Db.Abstractions;

public interface IDbCmd
{
    long Id { get; init; }
    long UsrId { get; init; }
    IDbCmdResult Result { get; set; }
}
