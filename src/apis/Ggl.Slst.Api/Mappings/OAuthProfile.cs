using AutoMapper;

namespace Ggl.Slst.Api.Mappings;

public class OAuthProfile : Profile
{
    public OAuthProfile()
    {
        CreateMap<User, UpsertUsrDbCmd>()
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.FamilyName))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GivenName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}
