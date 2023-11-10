namespace Ggl.Slst.Api.Core;

internal class ReadLstManager : BaseManager, IManager<ReadLstReq, ReadLstResp>
{
    public ReadLstManager(
        IWriteDbResourceAccess writeDbResourceAccess,
        IReadDbResourceAccess readDbResourceAccess,
        ITypeMapper typeMapper
    ) : base(writeDbResourceAccess, readDbResourceAccess, typeMapper)
    {
    }
    
    public async Task<ReadLstResp> ManageAsync(
        ReadLstReq req, 
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var qry = this._TypeMapper.Map<ReadLstReq, GetLstDbQry>(ref req);

        var dbResp = await this._ReadDbResourceAccess.QueryFirstOrDefaultAsync<GetLstDbQry, GetLstDbQryResult>(qry);

        var resp = this._TypeMapper.Map<GetLstDbQryResult, ReadLstResp>(ref dbResp);

        return resp;
    }
}
