using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Repository.Repositories.Interfaces;
using ParkingGarage.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services
{
    public class VehicleService : IVehicleService
    {
        private const string CAR_LICENSE_PATTERN = @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$";
        private const string MOTORCYCLE_LICENSE_PATTERN = @"^(?:[A-Z]{2}[0-9]{4}|[A-Z]{1}[0-9]{5})$";
        protected readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _vehicleRepository.QueryHelper().GetAllAsync();
        }

        public async Task<Vehicle> GetVehicleByLicensePlate(string licensePlate)
        {
            var vehicle = await _vehicleRepository.QueryHelper().GetOneAsync(v => v.Id.Equals(licensePlate.ToUpper()));
            if (vehicle == null)
            {
                vehicle = vehicleTypeFromLicense(licensePlate);
                _vehicleRepository.Add(vehicle);
                await _vehicleRepository.SaveChangesAsync();
            }
            return vehicle;
        }

        private Vehicle vehicleTypeFromLicense(string licensePlate)
        {
            if (Regex.IsMatch(licensePlate, CAR_LICENSE_PATTERN))
            {
                return new Vehicle
                {
                    Id = licensePlate.ToUpper(),
                    ParkingStatus = ParkingStatus.LEFT,
                    Type = VehicleType.CAR,
                };
            } else if (Regex.IsMatch(licensePlate, MOTORCYCLE_LICENSE_PATTERN))
            {
                return new Vehicle
                {
                    Id = licensePlate.ToUpper(),
                    ParkingStatus = ParkingStatus.LEFT,
                    Type = VehicleType.MOTORCYCLE,
                };
            } else
            {
                return null;
            }
        }
    }
}
