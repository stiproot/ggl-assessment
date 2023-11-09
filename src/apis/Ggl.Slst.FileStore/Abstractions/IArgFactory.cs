namespace Ggl.Slst.FileStore.Abstractions;

public interface IArgFactory
{
    GetObjectArgs GetObjectArgs(
        string objectName, 
        string fileName
    );
    BucketExistsArgs BucketExistsArgs();
    ListObjectsArgs ListObjectsArgs(string prefix);
    PutObjectArgs PutObjectArgs(
        string objectName, 
        string fileName,
        string contentType
    );
    RemoveObjectArgs RemoveObjectArgs(string objectName);
}