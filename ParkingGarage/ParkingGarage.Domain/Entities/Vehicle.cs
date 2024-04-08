using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Domain.Entities
{
    [Table("vehicle")]
    public class Vehicle : BaseEntity<string>
    {
        public VehicleType Type { get; set; }
        public ParkingStatus ParkingStatus { get; set; } 
        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
