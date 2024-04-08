using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Dto.Ticket;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IVehicleService _vehicleService;

        public TicketController(ITicketService ticketService, IVehicleService vehicleService)
        {
            _ticketService = ticketService;
            _vehicleService = vehicleService;
        }

        //[HttpPost]
        //public async Task<ActionResult<Ticket>> CreateTicket([FromBody] CreateTicketDto createTicketDto)
        //{
        //    var vehicle = await _vehicleService.GetVehicle(createTicketDto.VehicleId);
        //    var ticket = new Ticket
        //    {
        //        VehicleId = vehicle.Id,
        //        ParkTime = DateTime.Now,
        //    };
        //    var createdTicket = await _ticketService.CreateTicket(ticket);
        //    return createdTicket;
        //}
    }
}
