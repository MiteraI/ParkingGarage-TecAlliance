using ParkingGarage.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Domain.Entities
{
    [Table("floor")]
    public class Floor : BaseEntity<long>
    {
        public int PhysicalFloor { get; set; }
        [Length(2,2)] 
        public string FloorCode { get; set; }
        public VehicleType FloorType { get; set; }
        public IList<ParkingSlot> ParkingSlots { get; set; } = new List<ParkingSlot>();
    }
}
