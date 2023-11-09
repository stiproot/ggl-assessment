namespace Ggl.Slst.FileStore.Abstractions;

public interface IFileStoreCmd
{
    string Name { get; init; }
    IFileStoreCmdResult Result { get; set; }
}
