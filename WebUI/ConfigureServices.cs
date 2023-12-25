using ETAPP.Application.Common.Interfaces;
using ETAPP.Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using WebUI.Services;

namespace AccountingSystem.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IUserContext, HttpUserContext>();
        //services.AddScoped<IIdentityService, IdentityService>();
        services.AddHttpContextAccessor();

        return services;
    }
}
 