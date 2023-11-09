namespace Ggl.Slst.FileStore.Abstractions;

public class EmptyCmdResult : IFileStoreCmdResult
{
    public string Name { get; init; } = string.Empty;
}
