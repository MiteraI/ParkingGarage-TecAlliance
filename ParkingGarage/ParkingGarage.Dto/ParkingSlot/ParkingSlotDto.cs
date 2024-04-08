using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.ParkingSlot
{
    public class ParkingSlotDto
    {
        public long? Id { get; set; }
        public double PricePerHour { get; set; }
        [Length(5, 5)]
        public string SlotCode { get; set; }
        public SlotStatus Status { get; set; }
    }
}
