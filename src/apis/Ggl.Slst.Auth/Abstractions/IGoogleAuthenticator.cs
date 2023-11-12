namespace Ggl.Slst.Auth.Abstractions;

public interface IGoogleAuthenticator
{
    Task GoogleSignIn();
    Task<ExtAccessTokenResp> GetAccessTokenFromCodeAsync(string code);
}