using System.Security.Claims;

namespace Ggl.Slst.Auth.Abstractions;

public interface IJwtService
{
    string BuildToken(ref IEnumerable<Claim> claims);
    IEnumerable<Claim> BuildClaims(ref User user);
}
