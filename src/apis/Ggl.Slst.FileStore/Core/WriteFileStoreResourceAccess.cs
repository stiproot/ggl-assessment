namespace Ggl.Slst.FileStore.Core;

public class WriteFileStoreResourceAccess : BaseFileStoreResourceAccess, IWriteFileStoreResourceAccess
{
    public WriteFileStoreResourceAccess(
        IMinioClient client,
        IArgFactory argFactory
    ) : base(client, argFactory) { }

    public async Task UpsertImgAsync(
        UpsertImgFileStoreCmd cmd,
        CancellationToken cancellationToken
    )
    {
        var arg = this._ArgFactory.PutObjectArgs(cmd.ObjectName, cmd.FileName, cmd.ContentType);

        await this._Client.PutObjectAsync(arg);
    }

    public async Task DeleteImgAsync(
        DeleteImgFileStoreCmd cmd,
        CancellationToken cancellationToken
    )
    {
        var arg = this._ArgFactory.RemoveObjectArgs(cmd.ObjectName);

        await this._Client.RemoveObjectAsync(arg);
    }
}
