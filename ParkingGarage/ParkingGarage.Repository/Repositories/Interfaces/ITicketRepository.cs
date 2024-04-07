using ParkingGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Repository.Repositories.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket, long>
    {
    }
}
