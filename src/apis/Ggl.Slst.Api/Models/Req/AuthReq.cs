namespace Ggl.Slst.Api.Models;

internal record AuthReq : Req
{
    public string ExtAuthCode { get; init; } = string.Empty;
}