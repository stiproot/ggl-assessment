namespace Ggl.Slst.FileStore.Abstractions;

public interface IWriteFileStoreResourceAccess
{
    Task ExecuteAsync(
        IFileStoreCmd cmd,
        CancellationToken cancellationToken
    );
}
