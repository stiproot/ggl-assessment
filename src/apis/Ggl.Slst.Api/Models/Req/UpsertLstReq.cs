namespace Ggl.Slst.Api.Models;

internal record UpsertLstReq : Req
{
    public IEnumerable<long> ProductIds { get; init; } = new List<long>();
    public string Name { get; init; } = string.Empty;
}