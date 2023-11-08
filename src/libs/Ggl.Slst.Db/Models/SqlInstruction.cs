namespace Ggl.Slst.Db.Models;

public class SqlInsruction : ISqlInstruction
{
    public string Sql { get; init; } = string.Empty;
    public DynamicParameters Parameters { get; init; } = new();
    public CommandType CommandType { get; init; }
}
