namespace Ggl.Slst.Api.Models;

internal record LoginResp : Resp
{
    public string Uri { get; init; } = string.Empty;
}