using Ggl.Slst.Auth.Extensions;
using Ggl.Slst.Db.Extensions;
using Ggl.Slst.Mapping.Extensions;
using Ggl.Slst.FileStore.Extensions;
using Ggl.Slst.Api.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ggl.Slst.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        @this.TryAddScoped<IManager<AuthReq, AuthResp>, AuthManager>();
        @this.TryAddSingleton<IManager<UpsertImgReq, UpsertImgResp>, UpsertImgManager>();
        @this.TryAddSingleton<IManager<UpsertLstReq, UpsertLstResp>, UpsertLstManager>();
        @this.TryAddSingleton<IManager<DeleteLstReq, DeleteLstResp>, DeleteLstManager>();
        @this.TryAddSingleton<IManager<ReadLstReq, ReadLstResp>, ReadLstManager>();

        @this.AddAuthServices(configuration);
        @this.AddDbServices(configuration);
        @this.AddFileStoreServices();
        @this.AddMappingServices();

        @this.TryAddSingleton<IMapper>(new MapperConfiguration(config =>
        {
            config.AddProfile<ModelProfile>();
            config.AddProfile<OAuthProfile>();
        }).CreateMapper());

        @this.AddEndpointsApiExplorer();
        @this.AddSwaggerGen();

        return @this;
    }
}
