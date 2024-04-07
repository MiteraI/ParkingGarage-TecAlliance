using ParkingGarage.Service.Services;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Configuration
{
    public static class ServiceStartup
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
