namespace Ggl.Slst.Api.Core;

internal class UpsertLstManager : BaseManager, IManager<UpsertLstReq, UpsertLstResp>
{
    public UpsertLstManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess,
        ITypeMapper typeMapper
    ) : base(writeDbResourceAccess, readDbResourceAccess, typeMapper)
    {
    }
    
    public async Task<UpsertLstResp> ManageAsync(
        UpsertLstReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var cmd = this._TypeMapper.Map<UpsertLstReq, UpsertLstDbCmd>(ref req);

        await this._WriteDbResourceAccess.ExecuteAsync(cmd, cancellationToken);

        return new UpsertLstResp { };
    }
}
