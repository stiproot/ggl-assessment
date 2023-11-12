namespace Ggl.Slst.Api.Models;

internal record AuthResp : Resp
{
    public string Jwt { get; init; } = string.Empty;
}