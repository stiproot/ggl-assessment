using Microsoft.Extensions.Configuration;

namespace Ggl.Slst.FileStore.Core;

public class FileStoreClientFactory : IFileStoreClientFactory
{
    private readonly IConfiguration _configuration;

    public FileStoreClientFactory(IConfiguration configuration)
    {
        this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public IMinioClient Create()
    {
        // string bucketName = this._configuration["FileStore:Minio:BucketName"]!;
        string rootUsr = this._configuration["FileStore:Minio:RootUsr"]!;
        string rootPwd = this._configuration["FileStore:Minio:RootPwd"]!;
        string endpoint = this._configuration["FileStore:Minio:Endpoint"]!;

        var client = new MinioClient()
                                  .WithEndpoint(endpoint)
                                  .WithCredentials(rootUsr, rootPwd)
                                  .WithSSL(false)
                                  .Build();
        return client;
    }
}