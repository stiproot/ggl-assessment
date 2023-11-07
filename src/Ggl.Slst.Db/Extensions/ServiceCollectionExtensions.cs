namespace Ggl.Slst.Db.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseUtilityServices(
        this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        @this.TryAddSingleton<IDbConnectionFactory, DatabaseConnectionFactory>();
        @this.TryAddSingleton<IDapperWrapper, DapperWrapper>();
        @this.ConfigureOptions<DatabaseOptions>(configuration, nameof(DatabaseOptions));
        @this.TryAddSingleton<IReadDbResourceAccess, ReadDbResourceAccess>();
        @this.TryAddSingleton<IWriteDbResourceAccess, WriteDbResourceAccess>();
        @this.TryAddSingleton<ISqlCmdMapper, SqlCmdMapper>();
        @this.TryAddSingleton<ISqlQryMapper, SqlQryMapper>();

        return @this;
    }
}
