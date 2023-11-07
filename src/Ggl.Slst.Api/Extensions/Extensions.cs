using Microsoft.Extensions.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection @this)
    {
        @this.TryAddSingleton<IManager<RegisterReq, RegisterResp>, RegistrationManager>();
        @this.TryAddSingleton<IManager<LoginReq, LoginResp>, LoginManager>();
        @this.TryAddSingleton<IManager<UpsertLstReq, UpsertLstResp>, UpsertLstManager>();

        return @this;
    }
}
