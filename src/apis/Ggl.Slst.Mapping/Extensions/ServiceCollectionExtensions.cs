using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ggl.Slst.Mapping.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddMappingServices(this IServiceCollection @this)
    {
        @this.TryAddSingleton<ITypeMapper, TypeMapper>();
        return @this;
    }
}
