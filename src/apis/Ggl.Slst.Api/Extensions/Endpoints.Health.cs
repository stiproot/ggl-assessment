namespace Ggl.Slst.Api.Extensions;

internal static partial class Endpoints
{
    public static WebApplication MapHealthEndpoints(this WebApplication @this)
    {
        @this.MapGet("/health", () =>
        {
            return Results.Ok("Running :)");
        }).AllowAnonymous();

        return @this;
    }
}
