using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.Floor
{
    public class CreateFloorDto
    {
        public double SlotPrice { get; set; }
        public int SlotCount { get; set; }
        public int PhysicalFloor { get; set; }
        [Length(2, 2)]
        public string FloorCode { get; set; }
        public VehicleType FloorType { get; set; }
    }
}
