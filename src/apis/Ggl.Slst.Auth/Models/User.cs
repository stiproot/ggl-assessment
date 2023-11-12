namespace Ggl.Slst.Auth.Models;

public sealed class User
{
    public string Email { get; init; } = string.Empty;
    public string GivenName { get; init; } = string.Empty;
    public string FamilyName { get; init; } = string.Empty;
    public long Id { get; set; }
}