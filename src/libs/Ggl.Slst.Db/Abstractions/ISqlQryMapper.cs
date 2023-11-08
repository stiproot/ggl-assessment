namespace Ggl.Slst.Db.Abstractions;

public interface ISqlQryMapper
{
    ISqlInstruction Map(IDbQry qry);
    ISqlInstruction Map<TKey>(TKey key) where TKey : struct;
}
