namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication @this)
    {
        @this.MapPost("/auth/register",
            async (RegisterReq req, IManager<RegisterReq, RegisterResp> manager, CancellationToken cancellationToken) =>
        {
            var res = await manager.ManageAsync(req, cancellationToken);
            return Results.Ok(res);
        }).RequireAuthorization();

        @this.MapPost("/auth/login", 
            async (LoginReq req, IManager<LoginReq, LoginResp> manager, CancellationToken cancellationToken) =>
        {
            var res = await manager.ManageAsync(req, cancellationToken);

            // TODO: confirm this approach...
            return Results.Redirect(res.Uri);
        });

        @this.MapGet("/ext/auth", 
            async (HttpContext context, CancellationToken cancellationToken) =>
        {
            Console.WriteLine("ext/auth hit!");

            string accessToken = context.Request.Query["access_token"]!;
            int expiresIn = int.Parse(context.Request.Query["expires_in"]!);
            string tokenType = context.Request.Query["token_type"]!;
            string scope = context.Request.Query["scope"]!;
            string authUser = context.Request.Query["authuser"]!;

            Console.WriteLine($"access_token: {accessToken}, expires_in: {expiresIn}, token_type: {tokenType}, scope: {scope}");

            throw new NotImplementedException();
        });

        return @this;
    }
}
