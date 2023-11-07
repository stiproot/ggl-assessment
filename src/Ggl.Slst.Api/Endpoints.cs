internal static class Endpoints
{
    public static void MapEndpoints(this WebApplication @this)
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

        @this.MapPost("/lst/upsert", async (UpsertLstReq req, IManager<UpsertLstReq, UpsertLstResp> manager) =>
        {
            var res = await manager.ManageAsync(req);
            return Results.Ok(res);
        });

        @this.MapPost("/lst/delete", async (DeleteLstReq req, IManager<DeleteLstReq, DeleteLstResp> manager) =>
        {
            var res = await manager.ManageAsync(req);
            return Results.Ok(res);
        });

        @this.MapPost("/lst/read", async (ReadLstReq req, IManager<ReadLstReq, ReadLstResp> manager) =>
        {
            var res = await manager.ManageAsync(req);
            return Results.Ok(res);
        });
    }
}
