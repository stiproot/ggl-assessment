namespace Ggl.Slst.Db.Core;

public class ReadDbResourceAccess : IReadDbResourceAccess
{
    protected readonly IDbConnectionFactory _DatabaseConnectionFactory;
    protected readonly IDapperWrapper _DapperWrapper;
    protected readonly ISqlQryMapper _SqlQueryMapper;

    public ReadDbResourceAccess(
        IDbConnectionFactory databaseConnectionFactory,
        IDapperWrapper dapperWrapper,
        ISqlQryMapper sqlQueryMapper
    )
    {
        this._DatabaseConnectionFactory = databaseConnectionFactory ?? throw new ArgumentNullException(nameof(databaseConnectionFactory));
        this._DapperWrapper = dapperWrapper ?? throw new ArgumentNullException(nameof(dapperWrapper));
        this._SqlQueryMapper = sqlQueryMapper ?? throw new ArgumentNullException(nameof(sqlQueryMapper));
    }

    public async Task<IEnumerable<TDbQryResult>> QueryAsync<TDbQry, TDbQryResult>(TDbQry qry)
        where TDbQry : IDbQry
        where TDbQryResult : IDbQryResult
    {
        var instruction = this._SqlQueryMapper.Map(qry);
        using var connection = this._DatabaseConnectionFactory.Create();

        var result = await this._DapperWrapper.QueryAsync<TDbQryResult>(connection, instruction.Sql, instruction.Parameters);

        return result;
    }

    public async Task<TDbQryResult> QueryFirstOrDefaultAsync<TDbQry, TDbQryResult>(TDbQry qry)
        where TDbQry : IDbQry
        where TDbQryResult : IDbQryResult
    {
        var instruction = this._SqlQueryMapper.Map(qry);
        using var connection = this._DatabaseConnectionFactory.Create();

        var result = await this._DapperWrapper.QueryFirstOrDefaultAsync<TDbQryResult>(connection, instruction.Sql, instruction.Parameters, commandType: CommandType.StoredProcedure);

        return result;
    }
}
