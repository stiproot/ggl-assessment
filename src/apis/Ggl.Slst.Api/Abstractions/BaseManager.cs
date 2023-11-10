namespace Ggl.Slst.Api.Abstractions;

internal abstract class BaseManager
{
    protected readonly IWriteDbResourceAccess _WriteDbResourceAccess;
    protected readonly IReadDbResourceAccess _ReadDbResourceAccess;

    public BaseManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess
    )
    {
        this._WriteDbResourceAccess = writeDbResourceAccess ?? throw new ArgumentNullException(nameof(writeDbResourceAccess));
        this._ReadDbResourceAccess = readDbResourceAccess ?? throw new ArgumentNullException(nameof(readDbResourceAccess));
    }
}