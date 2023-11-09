namespace Ggl.Slst.FileStore.Core;

public class ReadFileStoreResourceAccess : BaseFileStoreResourceAccess, IReadFileStoreResourceAccess
{
    public ReadFileStoreResourceAccess(
        IFileStoreClientFactory fileStoreClientFactory,
        IArgFactory argFactory
    ) : base(fileStoreClientFactory, argFactory) 
    {
    }

    public async Task<GetImgFileStoreQryResult> GetImgAsync(GetImgFileStoreQry qry)
    {
        var arg = this._ArgFactory.GetObjectArgs(qry.ObjectName, qry.FileName);

        var client = this._FileStoreClientFactory.Create();

        var result = await client.GetObjectAsync(arg);

        return new GetImgFileStoreQryResult { ExtResult = result };
    }
}
