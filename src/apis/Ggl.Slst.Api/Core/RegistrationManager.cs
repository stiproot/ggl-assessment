namespace Ggl.Slst.Api.Core;

internal class RegistrationManager : IManager<RegisterReq, RegisterResp>
{
    public async Task<RegisterResp> ManageAsync(
        RegisterReq req,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        throw new NotImplementedException();
    }
}