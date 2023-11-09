namespace Ggl.Slst.FileStore.Core;

public class WriteFileStoreResourceAccess : IWriteFileStoreResourceAccess
{
    protected readonly IFileStoreConnectionFactory _DatabaseConnectionFactory;
    protected readonly IDapperWrapper _DapperWrapper;
    protected readonly ISqlCmdMapper _SqlCommandMapper;

    public WriteFileStoreResourceAccess(
        IFileStoreConnectionFactory databaseConnectionFactory,
        IDapperWrapper dapperWrapper,
        ISqlCmdMapper sqlCommandMapper
    )
    {
        this._DatabaseConnectionFactory = databaseConnectionFactory ?? throw new ArgumentNullException(nameof(databaseConnectionFactory));
        this._DapperWrapper = dapperWrapper ?? throw new ArgumentNullException(nameof(dapperWrapper));
        this._SqlCommandMapper = sqlCommandMapper ?? throw new ArgumentNullException(nameof(sqlCommandMapper));
    }

    public async Task ExecuteAsync(
        IFileStoreCmd cmd,
        CancellationToken cancellationToken,
        IFileStoreConnection? connection = null,
        IFileStoreTransaction? transaction = null
    )
    {
        var instruction = this._SqlCommandMapper.Map(cmd);
        if (connection is null)
        {
            using var _connection = this._DatabaseConnectionFactory.Create();
            long id = await this.ExecuteAsync(cmd, cancellationToken, _connection, instruction, transaction);
            cmd.Result = new BaseFileStoreCmdResult { Id = id };
        }
        else
        {
            long id = await this.ExecuteAsync(cmd, cancellationToken, connection, instruction, transaction);
            cmd.Result = new BaseFileStoreCmdResult { Id = id };
        }
    }

    private async Task<long> ExecuteAsync(
        IFileStoreCmd cmd,
        CancellationToken cancellationToken,
        IFileStoreConnection connection,
        ISqlInstruction instruction,
        IFileStoreTransaction? transaction
    )
    {
        return await this._DapperWrapper.QueryFirstOrDefaultAsync<long>(connection, instruction.Sql, instruction.Parameters, transaction: transaction);
    }
}
