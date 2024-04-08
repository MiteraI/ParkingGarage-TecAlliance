using ParkingGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> CreateParkingTicket(Ticket ticket);
        Task<Ticket> ExitParkingTicket(string licensePlate);
        Task<Ticket> CheckParkingTicket(string licensePlate);
        Task<IEnumerable<Ticket>> GetAllTickets();
    }
}
