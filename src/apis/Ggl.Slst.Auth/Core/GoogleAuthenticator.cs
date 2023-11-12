using System.Text.Json;
using Ggl.Slst.Auth.Extensions;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;

namespace Ggl.Slst.Auth.Core;

public sealed class GoogleAuthenticator : IGoogleAuthenticator
{
    private readonly OAuth2Options _oAuth2Options;

    public GoogleAuthenticator(IOptions<OAuth2Options> oAuth2Options) 
        => this._oAuth2Options = oAuth2Options.Value ?? throw new ArgumentNullException(nameof(oAuth2Options));

    public async Task<User> ValidateIdTokenAsync(string idToken)
    {
        var validationSettings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { this._oAuth2Options.ClientId },
        };

        GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(idToken, validationSettings);

        // TODO: use mapper?
        return new User
        {
            GivenName = payload.GivenName,
            FamilyName = payload.FamilyName,
            Email = payload.Email
        };
    }

    public async Task<ExtAccessTokenResp> GetAccessTokenFromCodeAsync(string code)
    {
        var parameters = new Dictionary<string, string>
        {
            { "code", code },
            { "client_id", this._oAuth2Options.ClientId },
            { "client_secret", this._oAuth2Options.ClientSecret },
            { "redirect_uri", this._oAuth2Options.RedirectUrl },
            { "grant_type", "authorization_code" },
            { "access_type", "offline" }
        };

        using var httpClient = new HttpClient();
        var resp = await httpClient.PostAsync(this._oAuth2Options.TokenEndpoint, parameters.ToFormUrlEncodedContent());
        resp.EnsureSuccessStatusCode();

        var content = await resp.Content.ReadAsStringAsync();
        var obj = JsonSerializer.Deserialize<ExtAccessTokenResp>(content) ?? throw new Exception("Failed to deserialize response");

        return obj;
    }
}