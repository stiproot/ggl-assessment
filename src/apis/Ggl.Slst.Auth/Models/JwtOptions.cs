namespace Ggl.Slst.Auth.Models;

public sealed class JwtOptions
{
    public string Secret { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int Expiration { get; set; }
}