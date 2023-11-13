namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapFileEndpoints(this WebApplication @this)
    {
        @this.MapPost("/img/upload", 
            async (UpsertImgReq req, IManager<UpsertImgReq, UpsertImgResp> manager, CancellationToken cancellationToken) =>
        {
            var res = await manager.ManageAsync(req, cancellationToken);
            return Results.Ok(res);
        })
            .RequireAuthorization()
            .WithName("Upload Img")
            .WithOpenApi();
        
        return @this;
    }
}
