namespace Ggl.Slst.FileStore.Abstractions;

public interface IWriteFileStoreResourceAccess
{
    Task UpsertImgAsync(
        UpsertImgFileStoreCmd cmd,
        CancellationToken cancellationToken
    );

    Task DeleteImgAsync(
        DeleteImgFileStoreCmd cmd,
        CancellationToken cancellationToken
    );
}
