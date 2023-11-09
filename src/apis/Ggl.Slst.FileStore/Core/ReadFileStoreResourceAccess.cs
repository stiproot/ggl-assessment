namespace Ggl.Slst.FileStore.Core;

public class ReadFileStoreResourceAccess : BaseFileStoreResourceAccess, IReadFileStoreResourceAccess
{
    public ReadFileStoreResourceAccess(
        IMinioClient client,
        IArgFactory argFactory
    ) : base(client, argFactory) { }

    public async Task<GetImgFileStoreQryResult> GetImgAsync(GetImgFileStoreQry qry)
    {
        var arg = this._ArgFactory.GetObjectArgs(qry.ObjectName, qry.FileName);

        var result = await this._Client.GetObjectAsync(arg);

        return new GetImgFileStoreQryResult { ExtResult = result };
    }
}
