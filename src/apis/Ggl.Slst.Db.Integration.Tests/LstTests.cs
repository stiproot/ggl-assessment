using System.Text.Json;

namespace Ggl.Slst.Db.Integration.Tests;

public class LstTests : BaseTests
{
    public LstTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        var lstName = Guid.NewGuid().ToString();
        var upsertCmd = new UpsertLstDbCmd { UsrId = 1, Name = lstName, ProductIds = new List<long> { 1, 2, 3 } };
        var readQry = new GetLstDbQry { UsrId = 1, QueryString = lstName };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetLstDbQry, GetLstDbQryResult>(readQry);

        Console.WriteLine(JsonSerializer.Serialize(readResult));

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.Name.Equals(lstName)));

        var deleteCmd = new DeleteLstDbCmd { Id = readResult.First().Id };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetLstDbQry, GetLstDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}