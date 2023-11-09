namespace Ggl.Slst.FileStore.Abstractions;

public abstract class BaseFileStoreQry
{
    public long ProductId { get; init; }
    public string ObjectName { get; init; } = string.Empty;
    public string FileName { get; init; } = string.Empty;
}
