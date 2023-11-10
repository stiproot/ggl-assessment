namespace Ggl.Slst.Api.Abstractions;

internal abstract record Req : IReq
{
    public long Id { get; init; }
    public long UsrId { get; init; }
}