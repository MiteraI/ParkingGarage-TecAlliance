using Microsoft.EntityFrameworkCore;
using ParkingGarage.Domain.Entities;

namespace ParkingGarage.Configuration
{
    public static class DatabaseStartup
    {
        public static void AddDatabaseModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AppDbContext");
            services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<DbContext>(provider => provider.GetService<ApplicationDatabaseContext>());
        }
    }
}
