namespace Ggl.Slst.Db.Abstractions;

public interface IReadDbResourceAccess
{
    Task<IEnumerable<TDbQryResult>> QueryAsync<TDbQry, TDbQryResult>(TDbQry qry)
        where TDbQry : IDbQry
        where TDbQryResult : IDbQryResult;

    Task<TDbQryResult> QueryFirstOrDefaultAsync<TDbQry, TDbQryResult>(TDbQry qry)
        where TDbQry : IDbQry
        where TDbQryResult : IDbQryResult;
}
