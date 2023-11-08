using System.Text.Json;

namespace Ggl.Slst.Db.Integration.Tests;

public class ProductTests : BaseTests
{
    public ProductTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        var desc = Guid.NewGuid().ToString();
        var code = Guid.NewGuid().ToString()[..24];
        var upsertCmd = new UpsertProductDbCmd { Description = desc, Code = code };
        var readQry = new GetProductDbQry { QueryString = desc };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetProductDbQry, GetProductDbQryResult>(readQry);

        Console.WriteLine(JsonSerializer.Serialize(readResult));

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.Description.Equals(desc)));

        var deleteCmd = new DeleteProductDbCmd { Id = readResult.First().Id };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetProductDbQry, GetProductDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}