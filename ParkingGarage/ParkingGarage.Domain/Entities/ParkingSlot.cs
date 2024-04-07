using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Domain.Entities
{
    [Table("parking_slot")]
    public class ParkingSlot : BaseEntity<long>
    {
        public double PricePerHour { get; set; }
        public SlotStatus Status { get; set; }
        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();
        public long FloorId { get; set; }
        public Floor? Floor { get; set; }
    }
}
