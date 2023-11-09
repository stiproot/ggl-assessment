namespace Ggl.Slst.FileStore;

// TODO: THIS IS A PROOF OF CONCEPT FOR MinIO... must remove
public static class MinioUploader
{
    const string endpoint = "127.0.0.1:9000";
    const string accessKey = "minioadmin";
    const string secretKey = "minioadmin";
    const string bucketName = "slst-imgs";
    const string filePath = "/Users/simon.stipcich/code/repo/ggl-assessment/tmp/pikachu.png";
    const string objectName = "pikachu.png";
    const string contentType = "image/png";

    public static async Task GetObjectAsync()
    {
        try
        {
            Console.WriteLine("Running example for API: GetObjectAsync");

            IMinioClient client = new MinioClient()
                                                .WithEndpoint(endpoint)
                                                .WithCredentials(accessKey, secretKey)
                                                .WithSSL(false)
                                                .Build();

            var args = new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithFile(objectName);

            var stat = await client.GetObjectAsync(args);

            Console.WriteLine($"Downloaded the file {filePath} in bucket {bucketName}");
            Console.WriteLine($"Stat details of object {objectName} in bucket {bucketName}\n" + stat);
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"[Bucket]  Exception: {e}");
        }
    }

    public async static Task BucketExistsAsync()
    {
        var secure = false;

        IMinioClient client = new MinioClient()
                                            .WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
                                            .WithSSL(secure)
                                            .Build();

        var beArgs = new BucketExistsArgs()
            .WithBucket(bucketName);

        bool found = await client.BucketExistsAsync(beArgs);

        Console.WriteLine(found);
    }

    public async static Task GetBucketsAsync()
    {
        var secure = false;

        IMinioClient client = new MinioClient()
                                            .WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
                                            .WithSSL(secure)
                                            .Build();

        var getListBucketsTask = await client.ListBucketsAsync();

        foreach (var bucket in getListBucketsTask.Buckets)
        {
            Console.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
        }
    }

    public async static Task UploadAsync()
    {
        var client = new MinioClient()
                                  .WithEndpoint(endpoint)
                                  .WithCredentials(accessKey, secretKey)
                                  .WithSSL(false)
                                  .Build();

        var beArgs = new BucketExistsArgs()
            .WithBucket(bucketName);

        bool found = await client.BucketExistsAsync(beArgs).ConfigureAwait(false);

        if (!found)
        {
            throw new Exception($"Bucket '{bucketName}' does not exist!");
        }

        var putObjectArgs = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithFileName(filePath)
            .WithContentType(contentType);

        await client.PutObjectAsync(putObjectArgs);

        Console.WriteLine("Successfully uploaded " + objectName);
    }

    public static void ListObjectsAsync(
        string bucketName = bucketName,
        string? prefix = null,
        bool recursive = true
    )
    {
        var client = new MinioClient()
                                .WithEndpoint(endpoint)
                                .WithCredentials(accessKey, secretKey)
                                .WithSSL(false)
                                .Build();

        Console.WriteLine("Running example for API: ListObjectsAsync");

        var listArgs = new ListObjectsArgs()
            .WithBucket(bucketName)
            .WithPrefix(prefix)
            .WithRecursive(recursive);

        var observable = client.ListObjectsAsync(listArgs);

        var subscription = observable.Subscribe(
            item => Console.WriteLine($"Object: {item.Key}"),
            ex => Console.WriteLine($"OnError: {ex}"),
            () => Console.WriteLine($"Listed all objects in bucket {bucketName}\n")
        );

        subscription.Dispose();
    }
}
