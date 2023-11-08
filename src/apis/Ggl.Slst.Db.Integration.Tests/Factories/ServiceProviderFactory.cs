using Ggl.Slst.Db.Extensions;

namespace Ggl.Slst.Db.Integration.Tests.Factories;

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
            .AddDbServices(configuration)
            .BuildServiceProvider();
    }
}