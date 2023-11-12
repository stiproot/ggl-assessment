using AutoMapper;

namespace Ggl.Slst.Api.Mappings;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<UpsertLstReq, UpsertLstDbCmd>();
        CreateMap<DeleteLstReq, DeleteLstDbCmd>();
        CreateMap<ReadLstReq, GetLstDbQry>();
        CreateMap<GetLstDbQryResult, ReadLstResp>();
    }
}