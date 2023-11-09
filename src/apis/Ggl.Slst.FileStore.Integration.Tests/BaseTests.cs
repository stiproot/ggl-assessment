namespace Ggl.Slst.FileStore.Integration.Tests;

public abstract class BaseTests
{
    protected readonly IServiceProvider _Provider = ServiceProviderFactory.Provider();
    protected readonly IWriteFileStoreResourceAccess _WriteFileStoreResourceAccess;
    protected readonly IReadFileStoreResourceAccess _ReadFileStoreResourceAccess;

    protected BaseTests()
    {
        this._WriteFileStoreResourceAccess = this._Provider.GetService<IWriteFileStoreResourceAccess>()!;
        this._ReadFileStoreResourceAccess = this._Provider.GetService<IReadFileStoreResourceAccess>()!; 
    }
}