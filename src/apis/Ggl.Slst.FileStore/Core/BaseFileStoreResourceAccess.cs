namespace Ggl.Slst.FileStore.Core;

public abstract class BaseFileStoreResourceAccess
{
    protected readonly IMinioClient _Client;
    protected readonly IArgFactory _ArgFactory; 

    public BaseFileStoreResourceAccess(
        IMinioClient client,
        IArgFactory argFactory
    )
    {
        this._Client = client ?? throw new ArgumentNullException(nameof(client));
        this._ArgFactory = argFactory ?? throw new ArgumentNullException(nameof(argFactory));
    }
}
