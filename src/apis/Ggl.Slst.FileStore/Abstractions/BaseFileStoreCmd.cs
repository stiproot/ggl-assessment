namespace Ggl.Slst.FileStore.Abstractions;

public abstract class BaseFileStoreCmd
{
    public string ObjectName { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;
    public string ContentType { get; init; } = string.Empty;
    public IFileStoreCmdResult Result { get; set; } = new EmptyCmdResult();
}
