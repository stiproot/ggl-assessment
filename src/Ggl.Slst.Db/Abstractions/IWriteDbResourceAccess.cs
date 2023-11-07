namespace Ggl.Slst.Db.Abstractions;

public interface IWriteDbResourceAccess
{
    Task ExecuteAsync(
        IDbCmd cmd,
        CancellationToken cancellationToken,
        IDbConnection? connection = null,
        IDbTransaction? transaction = null
    );
}
