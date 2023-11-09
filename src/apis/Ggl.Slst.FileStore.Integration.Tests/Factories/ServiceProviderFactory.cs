using Ggl.Slst.FileStore.Extensions;

namespace Ggl.Slst.FileStore.Integration.Tests.Factories;

public static class ServiceProviderFactory
{
    public static IServiceCollection Collection() => new ServiceCollection();

    public static IConfiguration Configuration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static IServiceProvider Provider()
    {
        var configuration = Configuration();

        return Collection()
            .AddSingleton(configuration)
            .AddFileStoreServices()
            .BuildServiceProvider();
    }
}