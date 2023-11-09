using Microsoft.Extensions.Configuration;

namespace Ggl.Slst.FileStore.Core;

public class ArgFactory : IArgFactory
{
    private readonly string _bucketName;

    public ArgFactory(IConfiguration configuration)
    {
        this._bucketName = configuration["FileStore:Minio:BucketName"]!;
    }

    public GetObjectArgs GetObjectArgs(
        string objectName, 
        string fileName
    )
    {
        return new GetObjectArgs()
            .WithBucket(this._bucketName)
            .WithObject(objectName)
            .WithFile(fileName);
    }

    public BucketExistsArgs BucketExistsArgs()
    {
        return new BucketExistsArgs();
    }

    public ListObjectsArgs ListObjectsArgs(string prefix)
    {
        return new ListObjectsArgs()
            .WithBucket(this._bucketName)
            .WithRecursive(true)
            .WithPrefix(prefix);
    }

    public PutObjectArgs PutObjectArgs(
        string objectName, 
        string fileName,
        string contentType
    )
    {
        return new PutObjectArgs()
            .WithBucket(this._bucketName)
            .WithObject(objectName)
            .WithFileName(fileName)
            .WithContentType(contentType);
    }   

    public RemoveObjectArgs RemoveObjectArgs(string objectName)
    {
        return new RemoveObjectArgs()
            .WithBucket(this._bucketName)
            .WithObject(objectName);
    }
}