using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ggl.Slst.Auth.Google.Extensions;

public static class ServiceCollectionExtensions
{
    // TODO: use IOptions pattern...
    const string CLIENT_ID_KEY = "OAuth2:Google:ClientId";
    const string CLIENT_SECRET_KEY = "OAuth2:Google:ClientSecret";

    public static IServiceCollection AddGoogleAuthServices(this IServiceCollection @this, 
        IConfiguration configuration
    )
    {
        @this.AddAuthentication(o =>
        {
            // This forces challenge results to be handled by Google OpenID Handler, so there's no
            // need to add an AccountController that emits challenges for Login.
            o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            // This forces forbid results to be handled by Google OpenID Handler, which checks if
            // extra scopes are required and does automatic incremental auth.
            o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
            // Default scheme that will handle everything else.
            // Once a user is authenticated, the OAuth2 token info is stored in cookies.
            o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddGoogleOpenIdConnect(options =>
        {
            options.ClientId = configuration[CLIENT_ID_KEY];
            options.ClientSecret = configuration[CLIENT_SECRET_KEY];
        });

        return @this;
    }
}