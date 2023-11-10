namespace Ggl.Slst.Mapping.Abstractions;

internal interface ITypeMapper
{
    TTrgt Map<TSrc, TTrgt>(ref TSrc source);
}
