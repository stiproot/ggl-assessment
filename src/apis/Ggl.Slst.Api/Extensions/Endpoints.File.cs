namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapFileEndpoints(this WebApplication @this)
    {
        // @this.MapPost("/auth/register", async (RegisterReq req, IManager<RegisterReq, RegisterResp> manager) =>
        // {
        //     var res = await manager.ManageAsync(req);
        //     return Results.Ok(res);
        // }).RequireAuthorization();
        
        return @this;
    }
}
