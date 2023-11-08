namespace Ggl.Slst.Db.Abstractions;

public interface IDapperWrapper
{
    Task<TDbQryResult> QueryFirstOrDefaultAsync<TDbQryResult>(
        IDbConnection connection,
        string sql,
        DynamicParameters parameters,
        CommandType commandType = CommandType.StoredProcedure,
        IDbTransaction? transaction = null
    );

    Task<IEnumerable<TDbQryResult>> QueryAsync<TDbQryResult>(
        IDbConnection connection,
        string sql,
        DynamicParameters parameters,
        CommandType commandType = CommandType.StoredProcedure,
        IDbTransaction? transaction = null
    );

    Task ExecuteCommandAsync(
        IDbConnection connection,
        string sql,
        DynamicParameters parameters,
        CommandType commandType = CommandType.Text,
        IDbTransaction? transaction = null
    );
}
