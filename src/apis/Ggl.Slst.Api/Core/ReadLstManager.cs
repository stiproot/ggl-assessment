namespace Ggl.Slst.Api.Core;

internal class ReadLstManager : BaseManager, IManager<ReadLstReq, ReadLstResp>
{
    public ReadLstManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess
    ) : base(writeDbResourceAccess, readDbResourceAccess)
    {
    }
    
    public async Task<ReadLstResp> ManageAsync(
        ReadLstReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        // TODO; implement mapper...
        var qry = new GetLstDbQry
        {
        };

        var resp = await this._ReadDbResourceAccess.QueryFirstOrDefaultAsync<GetLstDbQry, GetLstDbQryResult>(qry);

        return new ReadLstResp { };
    }
}
