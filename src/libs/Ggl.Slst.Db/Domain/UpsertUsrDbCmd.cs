namespace Ggl.Slst.Db.Domain;

public class UpsertUsrDbCmd : BaseDbCmd, IDbCmd
{
    public string Usrname { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Surname { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? Pwd { get; init; }
}