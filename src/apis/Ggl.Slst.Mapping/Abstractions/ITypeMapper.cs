namespace Ggl.Slst.Mapping.Abstractions;

public interface ITypeMapper
{
    TTrgt Map<TSrc, TTrgt>(ref TSrc source);
}
