namespace Ggl.Slst.Db.Integration.Tests;

public class LstTests
{
    private readonly IServiceProvider _provider = ServiceProviderFactory.Provider();
    private readonly IWriteDbResourceAccess _writeDbResourceAccess;
    private readonly IReadDbResourceAccess _readDbResourceAccess;

    public LstTests()
    {
        this._writeDbResourceAccess = this._provider.GetService<IWriteDbResourceAccess>()!;
        this._readDbResourceAccess = this._provider.GetService<IReadDbResourceAccess>()!; 
    }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        var upsertCmd = new UpsertLstDbCmd { Name = "lst_1", ProductIds = new List<long> { 1, 2, 3 } };
        var readQry = new GetLstDbQry { QueryString = "lst_1" };

        // ACT
        await this._writeDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._readDbResourceAccess.QueryAsync<GetLstDbQry, GetLstDbQryResult>(readQry);

        // ASSERT
        Assert.NotNull(readResult);
    }
}