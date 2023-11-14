namespace Ggl.Slst.Db.Domain;

public class UpsertExtAccessTokenDbCmd : BaseDbCmd, IDbCmd
{
    public string Token { get; init; } = string.Empty;
    public DateTime ExpirationTimestampUtc { get; init; } = DateTime.UtcNow;
    public string RefreshToken { get; init; } = string.Empty;
    public bool Inactive { get; init; }
}
