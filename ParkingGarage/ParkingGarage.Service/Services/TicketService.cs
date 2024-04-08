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

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
    }
}
