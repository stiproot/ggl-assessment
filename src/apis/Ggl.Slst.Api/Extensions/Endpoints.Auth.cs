namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication @this)
    {
        @this.MapPost("/auth/register", async (RegisterReq req, IManager<RegisterReq, RegisterResp> manager) =>
        {
            var res = await manager.ManageAsync(req);
            return Results.Ok(res);
        }).RequireAuthorization();

        @this.MapPost("/auth/login", async (LoginReq req, IManager<LoginReq, LoginResp> manager) =>
        {
            var res = await manager.ManageAsync(req);

            // TODO: confirm this approach...
            return Results.Redirect(res.Uri);
        });

        @this.MapGet("/ext/auth", async (HttpContext context) =>
        {
            throw new NotImplementedException();
        });

        return @this;
    }
}
