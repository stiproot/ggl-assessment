namespace Ggl.Slst.Api.Core;

internal class AuthManager : IManager<AuthReq, AuthResp>
{
    // TODO: is this manager necessary, as we are leaning towards middleware...
    public async Task<AuthResp> ManageAsync(
        AuthReq req,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        throw new NotImplementedException();
    }
}