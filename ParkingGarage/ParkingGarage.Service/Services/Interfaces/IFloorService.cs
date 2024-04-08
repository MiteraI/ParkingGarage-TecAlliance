using ParkingGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services.Interfaces
{
    public interface IFloorService
    {
        Task<Floor> CreateFloorWithParkingSlots(Floor floor, int parkingSlots, double slotPrice);
        Task<IEnumerable<Floor>> GetAllFloor();
        Task<Floor> GetFloorWithAllSlots(long floorId);
        Task DeleteFloor(long floorId);
    }
}
