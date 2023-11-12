using Newtonsoft.Json;

namespace Ggl.Slst.Auth.Models;

public sealed class ExtAccessTokenResp
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; } = default!;

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; } = default!;

    [JsonProperty("scope")]
    public string Scope { get; set; } = default!;

    [JsonProperty("token_type")]
    public string TokenType { get; set; } = default!;

    [JsonProperty("id_token")]
    public string IdToken { get; set; } = default!;
}