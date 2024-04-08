using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto.ParkingSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.Floor
{
    public class FloorDto
    {
        public long? Id { get; set; }
        public int? PhysicalFloor { get; set; }
        public string? FloorCode { get; set; }
        public VehicleType VehicleType { get; set; }
        public IList<ParkingSlotDto> ParkingSlots { get; set; } = new List<ParkingSlotDto>();
    }
}
