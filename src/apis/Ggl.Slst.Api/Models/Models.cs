internal interface IReq
{
}

internal interface IResp
{
}

internal record Req : IReq
{
}

internal record Resp : IResp
{
}

internal record LoginReq : Req
{
}

internal record LoginResp : Resp
{
    public string Uri { get; init; } = string.Empty;
}

internal record AuthReq : Req
{
}

internal record AuthResp : Resp
{
}

internal record RegisterReq : Req
{
}

internal record RegisterResp : Resp
{
}

internal record UpsertLstReq : Req
{
}

internal record UpsertLstResp : Resp
{
}

internal record ReadLstReq : Req
{
}

internal record ReadLstResp : Resp
{
}

internal record DeleteLstReq : Req
{
}

internal record DeleteLstResp : Resp
{
}