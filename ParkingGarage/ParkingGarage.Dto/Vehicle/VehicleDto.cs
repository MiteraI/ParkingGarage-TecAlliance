using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.Vehicle
{
    public class VehicleDto
    {
        [LicenseNumberValidation]
        public string LicensePlateNumber { get; set; }
        public VehicleType Type { get; set; }
    }
}
