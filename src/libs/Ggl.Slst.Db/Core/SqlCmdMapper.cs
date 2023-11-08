namespace Ggl.Slst.Db.Core;

public class SqlCmdMapper : ISqlCmdMapper
{
    protected readonly IDictionary<string, string> _CommandHash = new Dictionary<string, string>();

    public SqlCmdMapper() => this.Load();

    protected virtual void Load()
    {
        this._CommandHash.Add(typeof(UpsertLstDbCmd).FullName!, StoredProcs.UpsertLst);
        this._CommandHash.Add(typeof(DeleteLstDbCmd).FullName!, StoredProcs.DeleteLst);
        this._CommandHash.Add(typeof(UpsertImgDbCmd).FullName!, StoredProcs.UpsertImg);
        this._CommandHash.Add(typeof(DeleteImgDbCmd).FullName!, StoredProcs.DeleteImg);
        this._CommandHash.Add(typeof(UpsertUsrDbCmd).FullName!, StoredProcs.UpsertUsr);
        this._CommandHash.Add(typeof(DeleteUsrDbCmd).FullName!, StoredProcs.DeleteUsr);
        this._CommandHash.Add(typeof(UpsertProductDbCmd).FullName!, StoredProcs.UpsertProduct);
        this._CommandHash.Add(typeof(DeleteProductDbCmd).FullName!, StoredProcs.DeleteProduct);
    }

    public ISqlInstruction Map(IDbCmd cmd)
    {
        // TODO: this can be optimized! (cache the member info on startup)...
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
