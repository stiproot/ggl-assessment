namespace Ggl.Slst.Auth.Abstractions;

public interface IGoogleAuthenticator
{
    Task<User> ValidateIdTokenAsync(string idToken);
    Task<ExtAccessTokenResp> GetAccessTokenFromCodeAsync(string code);
}