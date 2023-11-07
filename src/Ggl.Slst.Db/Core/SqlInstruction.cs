namespace Ggl.Slst.Db.Core;

public class SqlInstruction : ISqlInstruction
{
    public string Sql { get; init; } = string.Empty;
    public DynamicParameters Parameters { get; init; } = new();
    public CommandType CommandType { get; init; }
}
