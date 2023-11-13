namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapLstEndpoints(this WebApplication @this)
    {
        @this.MapPost("/lst/upsert", 
            async (UpsertLstReq req, IManager<UpsertLstReq, UpsertLstResp> manager, CancellationToken cancellationToken) =>
        {
            var res = await manager.ManageAsync(req, cancellationToken);
            return Results.Ok(res);
        })
            .WithName("Upsert Lst")
            .WithOpenApi();

        @this.MapPost("/lst/delete", 
            async (DeleteLstReq req, IManager<DeleteLstReq, DeleteLstResp> manager, CancellationToken cancellationToken) =>
        {
            var res = await manager.ManageAsync(req, cancellationToken);
            return Results.Ok(res);
        })
            .WithName("Delete Lst")
            .WithOpenApi();

        @this.MapPost("/lst/read", 
            async (ReadLstReq req, IManager<ReadLstReq, ReadLstResp> manager, CancellationToken cancellationToken) =>
        {
            var res = await manager.ManageAsync(req, cancellationToken);
            return Results.Ok(res);
        })
            .WithName("Read Lst")
            .WithOpenApi();

        return @this;
    }
}
