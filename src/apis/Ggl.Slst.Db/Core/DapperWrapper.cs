namespace Ggl.Slst.Db.Core;

public class DapperWrapper : IDapperWrapper
{
    public DapperWrapper() { }

    public async Task<TDbQryResult> QueryFirstOrDefaultAsync<TDbQryResult>(
        IDbConnection connection,
        string sql,
        DynamicParameters parameters,
        CommandType commandType = CommandType.StoredProcedure,
        IDbTransaction? transaction = null
    )
        => await connection.QueryFirstOrDefaultAsync<TDbQryResult>(sql, parameters, commandType: commandType, transaction: transaction);

    public async Task<IEnumerable<TDbQryResult>> QueryAsync<TDbQryResult>(
        IDbConnection connection,
        string sql,
        DynamicParameters parameters,
        CommandType commandType = CommandType.StoredProcedure,
        IDbTransaction? transaction = null
    )
        => await connection.QueryAsync<TDbQryResult>(sql, parameters, commandType: commandType, transaction: transaction);

    public async Task ExecuteCommandAsync(
        IDbConnection connection,
        string sql,
        DynamicParameters parameters,
        CommandType commandType = CommandType.Text,
        IDbTransaction? transaction = null
    )
        => await connection.ExecuteAsync(sql, parameters, commandType: commandType, transaction: transaction);
}
