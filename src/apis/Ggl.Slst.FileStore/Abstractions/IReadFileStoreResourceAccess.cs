namespace Ggl.Slst.FileStore.Abstractions;

public interface IReadFileStoreResourceAccess
{
    Task<GetImgFileStoreQryResult> GetImgAsync(GetImgFileStoreQry qry);
}
