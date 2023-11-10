namespace Ggl.Slst.Api.Abstractions;

internal abstract class BaseManager
{
    protected readonly IWriteDbResourceAccess _WriteDbResourceAccess;
    protected readonly IReadDbResourceAccess _ReadDbResourceAccess;
    protected readonly ITypeMapper _TypeMapper;

    public BaseManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess,
        ITypeMapper typeMapper
    )
    {
        this._WriteDbResourceAccess = writeDbResourceAccess ?? throw new ArgumentNullException(nameof(writeDbResourceAccess));
        this._ReadDbResourceAccess = readDbResourceAccess ?? throw new ArgumentNullException(nameof(readDbResourceAccess));
        this._TypeMapper = typeMapper ?? throw new ArgumentNullException(nameof(typeMapper));
    }
}