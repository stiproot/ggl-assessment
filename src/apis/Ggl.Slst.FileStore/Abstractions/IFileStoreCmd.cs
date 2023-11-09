namespace Ggl.Slst.FileStore.Abstractions;

public interface IFileStoreCmd
{
    string ObjectName { get; init; }
    string FileName { get; init; }
    string ContentType { get; init; }
    IFileStoreCmdResult Result { get; set; }
}
