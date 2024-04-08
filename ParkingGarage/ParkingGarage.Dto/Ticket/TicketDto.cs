using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.Ticket
{
    public class TicketDto
    {
        public DateTime ParkTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public double TicketFee { get; set; }
        public TicketStatus Status { get; set; }
        public VehicleType VehicleType { get; set; }
        public string VehicleId { get; set; }
        public long ParkingSlotId { get; set; }
    }
}
