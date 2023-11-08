namespace Ggl.Slst.Db.Integration.Tests;

public abstract class BaseTests
{
    protected readonly IServiceProvider _Provider = ServiceProviderFactory.Provider();
    protected readonly IWriteDbResourceAccess _WriteDbResourceAccess;
    protected readonly IReadDbResourceAccess _ReadDbResourceAccess;

    protected BaseTests()
    {
        this._WriteDbResourceAccess = this._Provider.GetService<IWriteDbResourceAccess>()!;
        this._ReadDbResourceAccess = this._Provider.GetService<IReadDbResourceAccess>()!; 
    }
}