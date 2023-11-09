namespace Ggl.Slst.FileStore.Abstractions;

public interface IReadFileStoreResourceAccess
{
    Task<IEnumerable<TFileStoreQryResult>> QueryAsync<TFileStoreQry, TFileStoreQryResult>(TFileStoreQry qry)
        where TFileStoreQry : IFileStoreQry
        where TFileStoreQryResult : IFileStoreQryResult;

    Task<TFileStoreQryResult> QueryFirstOrDefaultAsync<TFileStoreQry, TFileStoreQryResult>(TFileStoreQry qry)
        where TFileStoreQry : IFileStoreQry
        where TFileStoreQryResult : IFileStoreQryResult;
}
