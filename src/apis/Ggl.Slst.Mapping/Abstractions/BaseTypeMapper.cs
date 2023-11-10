namespace Ggl.Slst.Mapping.Abstractions;

public abstract class BaseTypeMapper
{
    protected readonly IMapper _ObjMapper;

    protected BaseTypeMapper(IMapper objMapper)
        => this._ObjMapper = objMapper ?? throw new ArgumentNullException(nameof(objMapper));
}