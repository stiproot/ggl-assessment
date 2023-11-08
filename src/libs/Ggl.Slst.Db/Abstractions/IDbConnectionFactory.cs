namespace Ggl.Slst.Db.Abstractions;

public interface IDbConnectionFactory
{
    IDbConnection Create();
}
