namespace Ggl.Slst.Api.Core;

internal class LoginManager : IManager<LoginReq, LoginResp>
{
    public async Task<LoginResp> ManageAsync(
        LoginReq req,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        throw new NotImplementedException();
    }
}