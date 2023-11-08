using Ggl.Slst.Auth.Google.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

        return @this;
    }
}
