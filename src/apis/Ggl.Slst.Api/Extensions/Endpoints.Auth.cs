namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication @this)
    {
        @this.MapGet("/ext/auth", 
            async (HttpContext context, IManager<AuthReq, AuthResp> manager, CancellationToken cancellationToken) =>
        {
            if(context.Request.Query.TryGetValue("code", out var code) is false)
            {
                return Results.BadRequest("Authorization code required.");
            }

            // int expiresIn = int.Parse(context.Request.Query["expires_in"]!);
            // string tokenType = context.Request.Query["token_type"]!;
            // string scope = context.Request.Query["scope"]!;
            // string authUser = context.Request.Query["authuser"]!;

            var req = new AuthReq{ ExtAuthCode = code! };

            var resp = await manager.ManageAsync(req, cancellationToken);

            return Results.Ok(resp);

        }).AllowAnonymous();

        return @this;
    }
}
