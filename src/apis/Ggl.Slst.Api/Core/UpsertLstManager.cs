namespace Ggl.Slst.Api.Core;

internal class UpsertLstManager : BaseManager, IManager<UpsertLstReq, UpsertLstResp>
{
    public UpsertLstManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess
    ) : base(writeDbResourceAccess, readDbResourceAccess)
    {
    }
    
    public async Task<UpsertLstResp> ManageAsync(
        UpsertLstReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        // TODO; implement mapper...
        var cmd = new UpsertLstDbCmd
        {
        };

        await this._WriteDbResourceAccess.ExecuteAsync(cmd, cancellationToken);

        return new UpsertLstResp { };
    }
}
