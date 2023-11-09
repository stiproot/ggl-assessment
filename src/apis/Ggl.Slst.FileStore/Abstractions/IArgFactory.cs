namespace Ggl.Slst.FileStore.Abstractions;

public interface IArgFactory
{
    GetObjectArgs GetObjectArgs(
        string objectName, 
        string fileName
    );
    BucketExistsArgs BucketExistsArgs();
    ListObjectsArgs ListObjectsArgs();
    PutObjectArgs PutObjectArgs(
        string objectName, 
        string fileName,
        string contentType
    );
}


        // var beArgs = new BucketExistsArgs()

            // var args = new GetObjectArgs()
            //     .WithBucket(bucketName)
            //     .WithObject(objectName)
            //     .WithFile(objectName);

        // var listArgs = new ListObjectsArgs()
        //     .WithBucket(bucketName)
        //     .WithPrefix(prefix)
        //     .WithRecursive(recursive);

        // var putObjectArgs = new PutObjectArgs()
        //     .WithBucket(bucketName)
        //     .WithObject(objectName)
        //     .WithFileName(filePath)
        //     .WithContentType(contentType);
