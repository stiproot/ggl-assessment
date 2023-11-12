using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ggl.Slst.Auth.Core;

public class JwtService : IJwtService 
{
    private readonly JwtOptions _jwtOptions; 

    public JwtService(
        IOptions<JwtOptions> jwtOptions)
    {
        this._jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
    }

    public string BuildToken(IEnumerable<Claim> claims)
    {
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

        var signKey = new SymmetricSecurityKey(key);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            notBefore: DateTime.UtcNow,
            audience: _jwtOptions.Audience,
            expires: DateTime.UtcNow.AddSeconds(Convert.ToInt32(_jwtOptions.Expiration)),
            claims: claims,
            signingCredentials: new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    public IEnumerable<Claim> BuildClaims(User user)
    {
        var claims = new List<Claim>()
        {
            new(JwtClaimTypes.Id, user.Id),
            new(JwtClaimTypes.Email, user.Email),
            new(JwtClaimTypes.GivenName, user.GivenName),
            new(JwtClaimTypes.FamilyName, user.FamilyName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        return claims;
    }
}