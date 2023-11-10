namespace Ggl.Slst.Mapping;

public sealed class TypeMapper : BaseTypeMapper, ITypeMapper
{
    public TypeMapper(IMapper objMapper) : base(objMapper) { }

    public TTrgt Map<TSrc, TTrgt>(ref TSrc src)
        => this._ObjMapper.Map<TSrc, TTrgt>(src);
}