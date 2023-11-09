namespace Ggl.Slst.FileStore.Core;

public abstract class BaseFileStoreResourceAccess
{
    protected readonly IFileStoreClientFactory _FileStoreClientFactory;
    protected readonly IArgFactory _ArgFactory; 

    public BaseFileStoreResourceAccess(
        IFileStoreClientFactory fileStoreClientFactory,
        IArgFactory argFactory
    )
    {
        this._FileStoreClientFactory = fileStoreClientFactory ?? throw new ArgumentNullException(nameof(fileStoreClientFactory));
        this._ArgFactory = argFactory ?? throw new ArgumentNullException(nameof(argFactory));
    }
}
