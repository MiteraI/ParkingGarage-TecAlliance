using ParkingGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> GetVehicleByLicensePlate(string licensePlate);
        Task<IEnumerable<Vehicle>> GetAllVehicles();
    }
}
