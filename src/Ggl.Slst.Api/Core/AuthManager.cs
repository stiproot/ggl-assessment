using Ggl.Slst.Auth.Google;

internal class AuthManager : IManager<AuthReq, AuthResp>
{
    private readonly IGoogleOAuth2 _googleOAuth2;

    public AuthManager(IGoogleOAuth2 googleOAuth2)
    {
        _googleOAuth2 = googleOAuth2 ?? throw new ArgumentNullException(nameof(googleOAuth2));
    }

    public async Task<AuthResp> ManageAsync(AuthReq req)
    {
        await _googleOAuth2.AuthAsync();
        return new AuthResp{ };
    }
}