using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        //[HttpGet]
        //[Authorize(Roles = RolesConstants.ADMIN + "," + RolesConstants.SECURITY)]
        //public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        //{
        //    return await _vehicleService
        //}
    }
}
