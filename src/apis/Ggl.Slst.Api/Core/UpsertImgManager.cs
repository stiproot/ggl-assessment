namespace Ggl.Slst.Api.Core;

internal class UpsertImgManager : BaseManager, IManager<UpsertImgReq, UpsertImgResp>
{
    public UpsertImgManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess,
        ITypeMapper typeMapper
    ) : base(writeDbResourceAccess, readDbResourceAccess, typeMapper)
    {
    }
    
    public async Task<UpsertImgResp> ManageAsync(
        UpsertImgReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var cmd = this._TypeMapper.Map<UpsertImgReq, UpsertImgDbCmd>(ref req);

        await this._WriteDbResourceAccess.ExecuteAsync(cmd, cancellationToken);

        return new UpsertImgResp { };
    }
}
