using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ggl.Slst.Auth.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthServices(this IServiceCollection @this,
        IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection(nameof(JwtOptions));
        @this.Configure<JwtOptions>(jwtSection);

        var options = jwtSection.Get<JwtOptions>() ?? throw new ArgumentNullException(nameof(jwtSection));
        var secret = Encoding.ASCII.GetBytes(options.Secret);

        @this.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = true;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = options.Issuer,
                ValidAudience = options.Audience,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(secret)
            };
        });

        @this.TryAddScoped<IGoogleAuthenticator, GoogleAuthenticator>();
        @this.TryAddSingleton<IJwtService, JwtService>();
        // @this.TryAddSingleton<IJwtTokenHandler, JwtTokenHandler>();

        return @this;
    }
}