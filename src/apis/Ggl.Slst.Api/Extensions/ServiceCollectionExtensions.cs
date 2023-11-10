using Ggl.Slst.Auth.Google.Extensions;
using Ggl.Slst.Db.Extensions;
using Ggl.Slst.Mapping.Extensions;
using Ggl.Slst.FileStore.Extensions;
using Ggl.Slst.Api.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ggl.Slst.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        @this.TryAddSingleton<IManager<AuthReq, AuthResp>, AuthManager>();
        @this.TryAddSingleton<IManager<RegisterReq, RegisterResp>, RegistrationManager>();
        @this.TryAddSingleton<IManager<LoginReq, LoginResp>, LoginManager>();

        @this.TryAddSingleton<IManager<UpsertLstReq, UpsertLstResp>, UpsertLstManager>();
        @this.TryAddSingleton<IManager<DeleteLstReq, DeleteLstResp>, DeleteLstManager>();
        @this.TryAddSingleton<IManager<ReadLstReq, ReadLstResp>, ReadLstManager>();

        // TODO: make this configurable (factory pattern)...
        @this.AddGoogleAuthServices(configuration);
        @this.AddDbServices(configuration);
        @this.AddFileStoreServices();
        @this.AddMappingServices();

        @this.TryAddSingleton<IMapper>(new MapperConfiguration(config =>
        {
            config.AddProfile<ModelProfile>();
        }).CreateMapper());

        return @this;
    }
}
