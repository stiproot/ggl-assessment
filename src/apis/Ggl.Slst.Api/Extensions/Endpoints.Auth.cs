using Ggl.Slst.Auth;
using Ggl.Slst.Auth.Abstractions;

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
            // var res = await manager.ManageAsync(req, cancellationToken);

            // // TODO: confirm this approach...
            // return Results.Redirect(res.Uri);

            return Results.Ok();

        }).RequireAuthorization();

        @this.MapGet("/ext/auth", 
            async (HttpContext context, IGoogleAuthenticator authenticator, CancellationToken cancellationToken) =>
        {
            // Console.WriteLine("ext/auth hit!");

            // string code = context.Request.Query["code"]!;
            // Console.WriteLine(code);

            // string accessToken = await authenticator.ExchangeCodeForAccessTokenAsync(code);
            // Console.WriteLine(accessToken);

            // // Console.WriteLine(context.);

            // Console.WriteLine(context.Request.QueryString.Value);

            // Console.WriteLine(context.Request.Query.Count());

            // foreach(var param in context.Request.Query)
            // {
            //     // Console.WriteLine($"{param.Key}: {context.Request.Query[param.Key]}");
            //     Console.WriteLine($"{param.Key}: {context.Request.Query[param.Key]}");
            // }

            // string accessToken = context.Request.Query["access_token"]!;
            // string userId = jwtTokenHandler.DecodeUserId(accessToken);

            // int expiresIn = int.Parse(context.Request.Query["expires_in"]!);
            // string tokenType = context.Request.Query["token_type"]!;
            // string scope = context.Request.Query["scope"]!;
            // string authUser = context.Request.Query["authuser"]!;

            // Console.WriteLine($"access_token: {accessToken}, userId: {userId}, expires_in: {expiresIn}, token_type: {tokenType}, scope: {scope}");

            // throw new NotImplementedException();

            return Results.Accepted();

        }).AllowAnonymous();

        return @this;
    }
}
