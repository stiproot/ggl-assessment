using System.Text.Json;
using Minio.Exceptions;

namespace Ggl.Slst.FileStore.Integration.Tests;

public class ImgTests : BaseTests
{
    const string ImgName = "pikachu.png";
    const string ContentType = "image/png";

    private string CurrentDir() => Directory.GetCurrentDirectory();
    private string ImgPath() => Path.Combine(CurrentDir(), ImgName);

    public ImgTests() : base() { }

    [Fact]
    public async Task All()
    {
        // ARRANGE
        var cancellationToken = new CancellationToken();
        Console.WriteLine(ImgPath());
        var upsertCmd = new UpsertImgFileStoreCmd { ContentType = ContentType, FileName = ImgPath(), ObjectName = ImgName };
        var readQry = new GetImgFileStoreQry { FileName = ImgName, ObjectName = ImgName };

        // ACT
        await this._WriteFileStoreResourceAccess.UpsertImgAsync(upsertCmd, cancellationToken);
        var readResult = await this._ReadFileStoreResourceAccess.GetImgAsync(readQry);

        Console.WriteLine(JsonSerializer.Serialize(readResult));

        // ASSERT
        Assert.NotNull(readResult);

        var deleteCmd = new DeleteImgFileStoreCmd { ObjectName = ImgName };
        await this._WriteFileStoreResourceAccess.DeleteImgAsync(deleteCmd, cancellationToken);

        await Assert.ThrowsAsync<ObjectNotFoundException>(async () => await this._ReadFileStoreResourceAccess.GetImgAsync(readQry));
    }
}