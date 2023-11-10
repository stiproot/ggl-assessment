namespace Ggl.Slst.Api.Core;

internal class DeleteLstManager : BaseManager, IManager<DeleteLstReq, DeleteLstResp>
{
    public DeleteLstManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess
    ) : base(writeDbResourceAccess, readDbResourceAccess)
    {
    }
    
    public async Task<DeleteLstResp> ManageAsync(
        DeleteLstReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        // TODO; implement mapper...
        var cmd = new DeleteLstDbCmd
        {
        };

        await this._WriteDbResourceAccess.ExecuteAsync(cmd, cancellationToken);

        return new DeleteLstResp { };
    }
}
