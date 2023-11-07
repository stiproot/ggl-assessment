namespace Ggl.Slst.Db.Core;

public class SqlCmdMapper : ISqlCmdMapper
{
    protected readonly IDictionary<string, string> _CommandHash = new Dictionary<string, string>();

    public SqlCmdMapper()
    {
        this.Load();
    }

    protected virtual void Load()
    {
        this._CommandHash.Add(typeof(UpsertSLstDbCmd).FullName!, StoredProcs.UpsertSLst);
        this._CommandHash.Add(typeof(DeleteSLstDbCmd).FullName!, StoredProcs.DeleteSLst);
    }

    public ISqlInstruction Map(IDbCmd cmd)
    {
        Type commandTypeInfo = cmd.GetType();
        MemberInfo[] membersInfo = commandTypeInfo
            .GetMembers()
            .Where(m => m.MemberType == MemberTypes.Property && m.Name != nameof(IDbCmd.Result))
            .ToArray();

        if (this._CommandHash.TryGetValue(commandTypeInfo.FullName!, out var sqlCommand) is false)
        {
            throw new SqlCommandNotFoundException($"A cmd for key {commandTypeInfo.FullName} not found.");
        }

        var parameters = new DynamicParameters();
        foreach (var member in membersInfo)
        {
            var v = commandTypeInfo.GetProperty(member.Name)!.GetValue(cmd);
            parameters.Add($"@{member.Name.ToPostgresParameter()}", v);
        }

        return new SqlInstruction
        {
            Sql = sqlCommand,
            Parameters = parameters
        };
    }
}
