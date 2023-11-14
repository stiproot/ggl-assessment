using System.Text.Json;

namespace Ggl.Slst.Db.Integration.Tests;

public class ExtAccessTokenTests : BaseTests
{
    public ExtAccessTokenTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        var token = Guid.NewGuid().ToString();
        var refreshToken = Guid.NewGuid().ToString();
        var expirationTimestampUtc = DateTime.Now;
        var upsertCmd = new UpsertExtAccessTokenDbCmd
        {
            Id = 0,
            UsrId = USER_ID,
            Token = token,
            RefreshToken = refreshToken,
            ExpirationTimestampUtc = expirationTimestampUtc
        };
        var readQry = new GetExtAccessTokenDbQry { UsrId = USER_ID };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetExtAccessTokenDbQry, GetExtAccessTokenDbQryResult>(readQry);

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.Token.Equals(token)));

        var deleteCmd = new DeleteExtAccessTokenDbCmd { Id = readResult.First().Id, UsrId = USER_ID };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetExtAccessTokenDbQry, GetExtAccessTokenDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}
