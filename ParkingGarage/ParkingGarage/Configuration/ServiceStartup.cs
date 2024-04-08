using ParkingGarage.Service.Services;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Configuration
{
    public static class ServiceStartup
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IParkingSlotService, ParkingSlotService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
