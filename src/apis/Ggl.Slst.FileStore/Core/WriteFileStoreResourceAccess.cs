namespace Ggl.Slst.FileStore.Core;

public class WriteFileStoreResourceAccess : BaseFileStoreResourceAccess, IWriteFileStoreResourceAccess
{
    public WriteFileStoreResourceAccess(
        IFileStoreClientFactory fileStoreClientFactory,
        IArgFactory argFactory
    ) : base(fileStoreClientFactory, argFactory) 
    {
    }

    public async Task UpsertImgAsync(
        UpsertImgFileStoreCmd cmd,
        CancellationToken cancellationToken
    )
    {
        var arg = this._ArgFactory.PutObjectArgs(cmd.ObjectName, cmd.FileName, cmd.ContentType);

        var client = this._FileStoreClientFactory.Create();

        await client.PutObjectAsync(arg);
    }

    public async Task DeleteImgAsync(
        DeleteImgFileStoreCmd cmd,
        CancellationToken cancellationToken
    )
    {
        var arg = this._ArgFactory.RemoveObjectArgs(cmd.ObjectName);

        var client = this._FileStoreClientFactory.Create();

        await client.RemoveObjectAsync(arg);
    }
}
