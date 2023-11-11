namespace Ggl.Slst.Api.Core;

internal class ExtAccessTokenManager : IManager<TokenReq, TokenResp>
{
    public async Task<TokenResp> ManageAsync(
        TokenReq req,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        throw new NotImplementedException();
    }
}