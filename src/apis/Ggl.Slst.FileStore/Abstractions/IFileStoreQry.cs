namespace Ggl.Slst.FileStore.Abstractions;

public interface IFileStoreQry
{
    public long ProductId { get; init; }
    public string ObjectName { get; init; }
    public string FileName { get; init; }
}
