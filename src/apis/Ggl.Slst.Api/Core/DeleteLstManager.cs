namespace Ggl.Slst.Api.Core;

internal class DeleteLstManager : BaseManager, IManager<DeleteLstReq, DeleteLstResp>
{
    public DeleteLstManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess,
        ITypeMapper typeMapper
    ) : base(writeDbResourceAccess, readDbResourceAccess, typeMapper)
    {
    }
    
    public async Task<DeleteLstResp> ManageAsync(
        DeleteLstReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var cmd = this._TypeMapper.Map<DeleteLstReq, DeleteLstDbCmd>(ref req);

        await this._WriteDbResourceAccess.ExecuteAsync(cmd, cancellationToken);

        return new DeleteLstResp { };
    }
}
