using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ggl.Slst.FileStore.Minio.Extensions;

public static class ServiceCollectionExtensions
{
    // TODO: use IOptions pattern...
    const string ROOT_USR_KEY = "FileStore:Minio:RootUsr";
    const string ROOT_PWD_KEY = "FileStore:Minio:RootPwd";
    const string ENDPOINT_KEY = "FileStore:Minio:Endpoint";

    public static IServiceCollection AddMinioServices(this IServiceCollection @this, 
        IConfiguration configuration
    )
    {
        string rootUsr = configuration[ROOT_USR_KEY]!;
        string rootPwd = configuration[ROOT_PWD_KEY]!;
        string endpoint = configuration[ENDPOINT_KEY]!;

        @this.AddMinio(configureClient => configureClient
            .WithEndpoint(endpoint)
            .WithCredentials(rootUsr, rootPwd));

        return @this;
    }
}