using Microsoft.Extensions.DependencyInjection;

namespace Ggl.Slst.FileStore.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFileStoreServices(this IServiceCollection @this)
    {
        @this.AddSingleton<IWriteFileStoreResourceAccess, WriteFileStoreResourceAccess>();
        @this.AddSingleton<IReadFileStoreResourceAccess, ReadFileStoreResourceAccess>();
        @this.AddSingleton<IArgFactory, ArgFactory>();
        @this.AddSingleton<IFileStoreClientFactory, FileStoreClientFactory>();

        return @this;
    }
}