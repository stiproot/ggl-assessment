using System.Text.Json;

namespace Ggl.Slst.Db.Integration.Tests;

public class ProductImgMappingTests : BaseTests
{
    public ProductImgMappingTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        int productId = 1;
        int imgId = 1;
        string thumbnailUrl = "thumbnail_url";
        var upsertCmd = new InsertProductImgMappingDbCmd { ProductId = productId, ImgId = imgId };
        var readQry = new GetProductImgMappingDbQry { ProductId = productId };

        // ACT
        await this._WriteDbResourceAccess.ExecuteAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadDbResourceAccess.QueryAsync<GetProductImgMappingDbQry, GetProductImgMappingDbQryResult>(readQry);

        Console.WriteLine(JsonSerializer.Serialize(readResult));

        // ASSERT
        Assert.Single(readResult);
        Assert.NotNull(readResult.FirstOrDefault(r => r.ThumbnailUrl.Equals(thumbnailUrl)));

        var deleteCmd = new DeleteProductImgMappingDbCmd { Id = readResult.First().Id };
        await this._WriteDbResourceAccess.ExecuteAsync(deleteCmd, cancellationToken);

        readResult = await this._ReadDbResourceAccess.QueryAsync<GetProductImgMappingDbQry, GetProductImgMappingDbQryResult>(readQry);
        Assert.Empty(readResult);
    }
}