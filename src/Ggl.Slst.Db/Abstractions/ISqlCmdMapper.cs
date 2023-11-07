namespace Ggl.Slst.Db.Abstractions;

public interface ISqlCmdMapper
{
    ISqlInstruction Map(IDbCmd cmd);
}
