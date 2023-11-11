namespace Ggl.Slst.Db.Core;

public class SqlQryMapper : ISqlQryMapper
{
    protected readonly IDictionary<string, string> _CommandHash = new Dictionary<string, string>();

    public SqlQryMapper() => this.Load();

    protected virtual void Load()
    {
        this._CommandHash.Add(typeof(GetLstDbQry).FullName!, StoredProcs.GetLst);
        this._CommandHash.Add(typeof(GetImgDbQry).FullName!, StoredProcs.GetImg);
        this._CommandHash.Add(typeof(GetUsrDbQry).FullName!, StoredProcs.GetUsr);
        this._CommandHash.Add(typeof(GetProductDbQry).FullName!, StoredProcs.GetProduct);
        this._CommandHash.Add(typeof(GetProductImgMappingDbQry).FullName!, StoredProcs.GetProductImgMapping);
        this._CommandHash.Add(typeof(GetExtAccessTokenDbQry).FullName!, StoredProcs.GetExtAccessToken);
    }

    public ISqlInstruction Map(IDbQry qry)
    {
        // TODO: this can be optimized! (cache the member info on startup)...
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
            PropertyInfo? pInfo = queryTypeInfo.GetProperty(member.Name) ?? throw new InvalidOperationException($"Property {member.Name} not found.");
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
