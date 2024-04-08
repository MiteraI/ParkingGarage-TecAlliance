using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Domain.Entities
{
    [Table("ticket")]
    public class Ticket : BaseEntity<long>
    {
        public DateTime ParkTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public double TicketFee { get; set; }
        public VehicleType VehicleType { get; set; }
        public string VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public long ParkingSlotId { get; set; }
        public ParkingSlot ParkingSlot { get; set; }
    }
}
