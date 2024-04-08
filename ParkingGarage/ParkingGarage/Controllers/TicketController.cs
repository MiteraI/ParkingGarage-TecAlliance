using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto.Ticket;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;
        private readonly IVehicleService _vehicleService;
        private readonly IParkingSlotService _parkingSlotService;

        public TicketController(IMapper mapper, 
            ITicketService ticketService, 
            IVehicleService vehicleService, 
            IParkingSlotService parkingSlotService)
        {
            _mapper = mapper;
            _ticketService = ticketService;
            _vehicleService = vehicleService;
            _parkingSlotService = parkingSlotService;
        }

        [HttpPost("enter")]
        [Authorize(Roles = RolesConstants.SECURITY)]
        public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] CreateTicketDto createTicketDto)
        {
            var vehicle = await _vehicleService.GetVehicleByLicensePlate(createTicketDto.LicensePlateNumber);
            if (vehicle == null)
            {
                return BadRequest("Vehicle not found");
            } else if (vehicle.ParkingStatus == ParkingStatus.PARKING)
            {
                return BadRequest("Vehicle is already parked");
            }

            var parkingSlot = await _parkingSlotService.GetVacantSlotFromVehicleType(vehicle.Type);
            if (parkingSlot == null)
            {
                return BadRequest("No available parking slot for this vehicle type");
            }

            var ticket = new Ticket
            {
                VehicleId = vehicle.Id,
                Vehicle = vehicle,
                ParkTime = DateTime.Now,
                VehicleType = vehicle.Type,
                Status = TicketStatus.ACTIVE,
                ParkingSlotId = parkingSlot.Id,
                ParkingSlot = parkingSlot
            };

            var createdTicket = await _ticketService.CreateParkingTicket(ticket);
            var createdTicketDto = _mapper.Map<TicketDto>(createdTicket);
            return createdTicketDto;
        }

        [HttpPost("exit")]
        [Authorize(Roles = RolesConstants.SECURITY)]
        public async Task<ActionResult<TicketDto>> ExitTicket([FromBody] CreateTicketDto exitTicketDto)
        {
            var ticket = await _ticketService.ExitParkingTicket(exitTicketDto.LicensePlateNumber);
            if (ticket == null)
            {
                return BadRequest("Ticket not found");
            }
            var createdTicketDto = _mapper.Map<TicketDto>(ticket);

            return createdTicketDto;
        }

    }
}
