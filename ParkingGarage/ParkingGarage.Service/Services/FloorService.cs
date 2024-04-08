using Microsoft.AspNetCore.Mvc;
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
    public class FloorService : IFloorService
    {
        protected readonly IParkingSlotRepository _parkingSlotRepository;
        protected readonly IFloorRepository _floorRepository;

        public FloorService(IParkingSlotRepository parkingSlotRepository, IFloorRepository floorRepository)
        {
            _parkingSlotRepository = parkingSlotRepository;
            _floorRepository = floorRepository;
        }

        public async Task<Floor> CreateFloorWithParkingSlots(Floor floor, int parkingSlots, double slotPrice)
        {
            var createdFloor = await _floorRepository.CreateOrUpdateAsync(floor);
            var creatingSlots = new List<ParkingSlot>();
            // Create parkings slot list to number of parkingSlots with slotPrice and the slotCode equals to floorCode + number like 001,002,...
            for (int i = 1; i <= parkingSlots; i++)
            {
                var parkingSlot = new ParkingSlot
                {
                    FloorId = createdFloor.Id,
                    SlotCode = $"{createdFloor.FloorCode}{i.ToString().PadLeft(3, '0')}",
                    Status = SlotStatus.VACANT,
                    PricePerHour = slotPrice
                };
                creatingSlots.Add(parkingSlot);
            }

            createdFloor.ParkingSlots = creatingSlots;
            await _floorRepository.SaveChangesAsync();

            return createdFloor;
        }

       
        public async Task DeleteFloor(long floorId)
        {
            var floor = await _floorRepository.GetOneAsync(floorId);
            await _floorRepository.DeleteAsync(floor);
            await _floorRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Floor>> GetAllFloor()
        {
            return await _floorRepository.GetAllAsync();
        }

        public async Task<Floor> GetFloorWithAllSlots(long floorId)
        {
            return await _floorRepository.QueryHelper().Include(x => x.ParkingSlots).GetOneAsync(f => f.Id == floorId);
        }
    }
}
