using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Repository.Repositories.Interfaces;
using ParkingGarage.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services
{
    public class ParkingSlotService : IParkingSlotService
    {
        private readonly IParkingSlotRepository _parkingSlotRepository;

        public ParkingSlotService(IParkingSlotRepository parkingSlotRepository)
        {
            _parkingSlotRepository = parkingSlotRepository;
        }

        public async Task<ParkingSlot> GetVacantSlotFromVehicleType(VehicleType vehicleType)
        {
            return await _parkingSlotRepository.QueryHelper().Filter(x => x.VehicleType == vehicleType && x.Status == SlotStatus.VACANT).FirstOrDefaultAsync();
        }
    }
}
