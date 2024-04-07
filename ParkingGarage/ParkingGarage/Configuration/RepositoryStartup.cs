using ParkingGarage.Repository.Repositories;
using ParkingGarage.Repository.Repositories.Interfaces;

namespace ParkingGarage.Configuration
{
    public static class RepositoryStartup
    {
        public static IServiceCollection AddRepositoryModule(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IParkingSlotRepository, ParkingSlotRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();

            return services;
        }
    }
}
