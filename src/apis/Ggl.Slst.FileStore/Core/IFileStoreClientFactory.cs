namespace Ggl.Slst.FileStore.Abstractions;

public interface IFileStoreClientFactory
{
    IMinioClient Create();
}