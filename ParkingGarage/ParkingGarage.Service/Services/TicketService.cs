using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Repository.Repositories.Interfaces;
using ParkingGarage.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services
{
    public class TicketService : ITicketService
    {
        protected readonly ITicketRepository _ticketRepository;
        protected readonly IVehicleRepository _vehicleRepository;
        protected readonly IParkingSlotRepository _parkingSlotRepository;

        public TicketService(ITicketRepository ticketRepository, IVehicleRepository vehicleRepository, IParkingSlotRepository parkingSlotRepository)
        {
            _ticketRepository = ticketRepository;
            _vehicleRepository = vehicleRepository;
            _parkingSlotRepository = parkingSlotRepository;
        }

        public async Task<Ticket> CreateParkingTicket(Ticket ticket)
        {
            var createdTicket = _ticketRepository.Add(ticket);
            createdTicket.Vehicle.ParkingStatus = ParkingStatus.PARKING;
            createdTicket.ParkingSlot.Status = SlotStatus.OCCUPIED;
            await _ticketRepository.SaveChangesAsync();
            return createdTicket;
        }

        public async Task<Ticket> ExitParkingTicket(string licensePlate)
        {
            var parkingTicket = await _ticketRepository.QueryHelper()
                .Include(t => t.ParkingSlot)
                .Include(t => t.Vehicle)
                .Filter(t => t.Vehicle.Id == licensePlate && t.Status == TicketStatus.ACTIVE).FirstOrDefaultAsync();
            if (parkingTicket == null) return null;

            // Calculate parking fee by exit time and enter time round to hour * parkingSlot.PricePerHour
            parkingTicket.LeaveTime = DateTime.Now;
            var parkingHours = (int)Math.Ceiling((parkingTicket.LeaveTime - parkingTicket.ParkTime).TotalHours);
            parkingTicket.TicketFee = parkingHours * parkingTicket.ParkingSlot.PricePerHour;

            // Update parkingSlot.Status to VACANT and vehicle.ParkingStatus to LEFT
            parkingTicket.ParkingSlot.Status = SlotStatus.VACANT;
            parkingTicket.Vehicle.ParkingStatus = ParkingStatus.LEFT;
            parkingTicket.Status = TicketStatus.PAID;

            await _ticketRepository.SaveChangesAsync();

            return parkingTicket;
        }
    }
}
