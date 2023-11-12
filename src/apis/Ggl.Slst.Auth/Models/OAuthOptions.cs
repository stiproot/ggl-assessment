namespace Ggl.Slst.Auth.Models;

public sealed class OAuth2Options
{
    public string ClientId { get; init; } = string.Empty;
    public string ClientSecret { get; init; } = string.Empty; 
    public string Issuer { get; init; } = string.Empty;
    public string RedirectUrl { get; init; } = string.Empty;
    public string TokenEndpoint { get; init; } = string.Empty;
}