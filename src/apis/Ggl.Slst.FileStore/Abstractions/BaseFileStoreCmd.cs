namespace Ggl.Slst.Db.Abstractions;

public abstract class BaseFileStoreCmd
{
    public string Name { get; init; } = string.Empty;
    public IFileStoreCmdResult Result { get; set; } = new EmptyCmdResult();
}
