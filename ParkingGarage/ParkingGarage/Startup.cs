using System;
using ParkingGarage.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ParkingGarage.Settings;

[assembly: ApiController]

namespace ParkingGarage;

public class Startup : IStartup
{
    public virtual void Configure(IConfiguration configuration, IServiceCollection services)
    {
        AddDatabase(configuration, services);
    }

    public virtual void ConfigureServices(IServiceCollection services, IHostEnvironment environment)
    {
        services
            .AddSecurityModule()
            .AddRepositoryModule()
            .AddServiceModule();
    }

    public virtual void ConfigureMiddleware(IApplicationBuilder app, IHostEnvironment environment)
    {
        IServiceProvider serviceProvider = app.ApplicationServices;
        var securitySettingsOptions = serviceProvider.GetRequiredService<IOptions<SecuritySettings>>();
        var securitySettings = securitySettingsOptions.Value;
        app
            .UseApplicationSecurity(securitySettings)
            .UseApplicationIdentity();
    }

    public virtual void ConfigureEndpoints(IApplicationBuilder app, IHostEnvironment environment)
    {
    }

    protected virtual void AddDatabase(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDatabaseModule(configuration);
    }
}
