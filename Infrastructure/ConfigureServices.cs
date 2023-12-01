
using Application.Common.Interfaces;
using ETAPP.Infrastructure.Identity;
using Infrastructure.Identity;
using Infrastructure.Identity.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                      builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

       services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

         services.AddDefaultIdentity<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();

        //services.AddSession(options =>
        //{
        //    // Set a short timeout for easy testing
        //    options.IdleTimeout = TimeSpan.FromMinutes(20);
        //    options.Cookie.HttpOnly = true;

        //    // Make the session cookie essential
        //    options.Cookie.IsEssential = true;
        //});

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/api/authentication/login";
                opt.LogoutPath = "/logout";
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromHours(12);
            });

        services.AddAuthorization();

        return services;
    }
}