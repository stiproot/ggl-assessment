internal class AuthManager : IManager<AuthReq, AuthResp>
{
    // TODO: is this manager necessary, as we are leaning towards middleware...
    public async Task<AuthResp> ManageAsync(AuthReq req)
    {
        throw new NotImplementedException();
    }
}