namespace Ggl.Slst.Db.Core;

public class SqlQryMapper : ISqlQryMapper
{
    protected readonly IDictionary<string, string> _CommandHash = new Dictionary<string, string>();

    public SqlQryMapper()
    {
        this.Load();
    }

    protected virtual void Load()
    {
        this._CommandHash.Add(typeof(SLstQry).FullName!, StoredProcs.GetSLst);
    }

    public ISqlInstruction Map(IDbQry qry)
    {
        var queryTypeInfo = qry.GetType();
        var membersInfo = queryTypeInfo
            .GetMembers()
            .Where(m => m.MemberType == MemberTypes.Property)
            .ToArray();

        if (this._CommandHash.TryGetValue(queryTypeInfo.FullName!, out var sqlCommand) is false)
        {
            throw new SqlCommandNotFoundException($"A qry for key {queryTypeInfo.FullName} not found.");
        }

        var parameters = new DynamicParameters();
        foreach (var member in membersInfo)
        {
            PropertyInfo? pInfo = queryTypeInfo.GetProperty(member.Name);
            if (pInfo is null)
            {
                throw new InvalidOperationException($"Property {member.Name} not found.");
            }

            parameters.Add($"@{member.Name!.ToPostgresParameter()}", pInfo.GetValue(qry));
        }

        return new SqlInstruction
        {
            Sql = sqlCommand,
            Parameters = parameters
        };
    }

    public ISqlInstruction Map<TKey>(TKey key) where TKey : struct
    {
        throw new NotImplementedException();
    }
}
