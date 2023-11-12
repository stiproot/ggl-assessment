using System.Security.Claims;

namespace Ggl.Slst.Auth.Abstractions;

public interface IJwtService
{
    string BuildToken(IEnumerable<Claim> claims);
    IEnumerable<Claim> BuildClaims(User user);
}
