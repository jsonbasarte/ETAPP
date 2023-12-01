using ETAPP.Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using WebUI.Services;

namespace AccountingSystem.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        //services.AddScoped<IIdentityService, IdentityService>();
        services.AddHttpContextAccessor();

        return services;
    }
}
 