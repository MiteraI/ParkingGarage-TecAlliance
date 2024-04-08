using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto.Floor;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api/floor")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpPost]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<ActionResult<Floor>> CreateFloor([FromBody] CreateFloorDto createFloorDto)
        {
            var floor = new Floor
            {
                PhysicalFloor = createFloorDto.PhysicalFloor,
                FloorCode = createFloorDto.FloorCode,
                FloorType = createFloorDto.FloorType
            };  
            var createdFloor = await _floorService.CreateFloorWithParkingSlots(floor, createFloorDto.SlotCount, createFloorDto.SlotPrice);
            createdFloor.ParkingSlots.ToList().ForEach(x => x.Floor = null);
            return createdFloor;
        }

        [HttpGet]
        public async Task<IEnumerable<Floor>> GetAllFloors()
        {
            return await _floorService.GetAllFloor();
        }

        [HttpGet("{floorId}")]
        public async Task<Floor> GetFloor([FromRoute] long floorId)
        {
            var floor = await _floorService.GetFloorWithAllSlots(floorId);
            floor.ParkingSlots.ToList().ForEach(x => x.Floor = null);
            return floor;
        }

        [HttpDelete("{floorId}")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<ActionResult> DeleteFloor([FromRoute] long floorId)
        {
            await _floorService.DeleteFloor(floorId);
            return Ok("Deleted floor");
        }
    }
}
