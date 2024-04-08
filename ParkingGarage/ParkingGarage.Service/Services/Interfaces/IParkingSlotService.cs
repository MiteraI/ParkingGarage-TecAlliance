using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services.Interfaces
{
    public interface IParkingSlotService
    {
        Task<ParkingSlot> GetVacantSlotFromVehicleType(VehicleType vehicleType);
    }
}
