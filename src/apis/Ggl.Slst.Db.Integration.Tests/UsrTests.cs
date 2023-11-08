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
        var usrName = Guid.NewGuid().ToString();
        var name = Guid.NewGuid().ToString();
        var surname = Guid.NewGuid().ToString();
        var email = $"{Guid.NewGuid()}@gmail.com";
        var pwd = Guid.NewGuid().ToString()[..24];
        var upsertCmd = new UpsertUsrDbCmd { Usrname = usrName, Name = name, Surname = surname, Pwd = pwd };
        var readQry = new GetUsrDbQry { QueryString = usrName };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetUsrDbQry, GetUsrDbQryResult>(readQry);

        Console.WriteLine(JsonSerializer.Serialize(readResult));

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.Usrname.Equals(usrName)));

        var deleteCmd = new DeleteUsrDbCmd { Id = readResult.First().Id };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetUsrDbQry, GetUsrDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}