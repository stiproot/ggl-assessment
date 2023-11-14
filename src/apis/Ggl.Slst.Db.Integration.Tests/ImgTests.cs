using System.Text.Json;

namespace Ggl.Slst.Db.Integration.Tests;

public class ImgTests : BaseTests
{
    public ImgTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        var url = Guid.NewGuid().ToString();
        var thumbnailUrl = Guid.NewGuid().ToString();
        var upsertCmd = new UpsertImgDbCmd { Url = url, ThumbnailUrl = thumbnailUrl };
        var readQry = new GetImgDbQry { QueryString = url };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetImgDbQry, GetImgDbQryResult>(readQry);

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.Url.Equals(url)));

        var deleteCmd = new DeleteImgDbCmd { Id = readResult.First().Id };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetImgDbQry, GetImgDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}
