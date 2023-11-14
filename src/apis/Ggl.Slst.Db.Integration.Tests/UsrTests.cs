using System.Text.Json;

namespace Ggl.Slst.Db.Integration.Tests;

public class UsrTests : BaseTests
{
    public UsrTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        var name = Guid.NewGuid().ToString();
        var surname = Guid.NewGuid().ToString();
        var email = $"{Guid.NewGuid()}@gmail.com";
        var upsertCmd = new UpsertUsrDbCmd { Name = name, Surname = surname, Email = email };
        var readQry = new GetUsrDbQry { QueryString = email };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetUsrDbQry, GetUsrDbQryResult>(readQry);

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.Email.Equals(email)));

        var deleteCmd = new DeleteUsrDbCmd { Id = readResult.First().Id };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetUsrDbQry, GetUsrDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}
