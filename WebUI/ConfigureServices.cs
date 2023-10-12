using ETAPP.Application.Common.Interfaces;
using WebUI.Services;

namespace AccountingSystem.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
