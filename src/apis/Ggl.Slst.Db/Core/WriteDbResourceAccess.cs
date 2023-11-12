namespace Ggl.Slst.Db.Core;

public class WriteDbResourceAccess : IWriteDbResourceAccess
{
    protected readonly IDbConnectionFactory _DatabaseConnectionFactory;
    protected readonly IDapperWrapper _DapperWrapper;
    protected readonly ISqlCmdMapper _SqlCommandMapper;

    public WriteDbResourceAccess(
        IDbConnectionFactory databaseConnectionFactory,
        IDapperWrapper dapperWrapper,
        ISqlCmdMapper sqlCommandMapper
    )
    {
        this._DatabaseConnectionFactory = databaseConnectionFactory ?? throw new ArgumentNullException(nameof(databaseConnectionFactory));
        this._DapperWrapper = dapperWrapper ?? throw new ArgumentNullException(nameof(dapperWrapper));
        this._SqlCommandMapper = sqlCommandMapper ?? throw new ArgumentNullException(nameof(sqlCommandMapper));
    }

    public async Task ExecuteAsync(
        IDbCmd cmd,
        CancellationToken cancellationToken,
        IDbConnection? connection = null,
        IDbTransaction? transaction = null
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var instruction = this._SqlCommandMapper.Map(cmd);
        if (connection is null)
        {
            using var _connection = this._DatabaseConnectionFactory.Create();
            long id = await this.ExecuteAsync(_connection, instruction, transaction);
            cmd.Result = new BaseDbCmdResult { Id = id };
        }
        else
        {
            long id = await this.ExecuteAsync(connection, instruction, transaction);
            cmd.Result = new BaseDbCmdResult { Id = id };
        }
    }

    private async Task<long> ExecuteAsync(
        IDbConnection connection,
        ISqlInstruction instruction,
        IDbTransaction? transaction
    )
    {
        return await this._DapperWrapper.QueryFirstOrDefaultAsync<long>(connection, instruction.Sql, instruction.Parameters, transaction: transaction);
    }
}
