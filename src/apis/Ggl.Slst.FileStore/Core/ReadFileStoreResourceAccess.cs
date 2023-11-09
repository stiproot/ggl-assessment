namespace Ggl.Slst.FileStore.Core;

public class ReadFileStoreResourceAccess : IReadFileStoreResourceAccess
{
    protected readonly IMinioClient _Client;

    public ReadFileStoreResourceAccess(IMinioClient client)
    {
        this._Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<IEnumerable<TFileStoreQryResult>> QueryAsync<TFileStoreQry, TFileStoreQryResult>(TFileStoreQry qry)
        where TFileStoreQry : IFileStoreQry
        where TFileStoreQryResult : IFileStoreQryResult
    {
        throw new NotImplementedException();
    }

    public async Task<TFileStoreQryResult> QueryFirstOrDefaultAsync<TFileStoreQry, TFileStoreQryResult>(TFileStoreQry qry)
        where TFileStoreQry : IFileStoreQry
        where TFileStoreQryResult : IFileStoreQryResult
    {
        // var result = await this._Client.GetObjectAsync<TFileStoreQryResult>(...);
        throw new NotImplementedException();
    }
}
