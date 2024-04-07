using ParkingGarage.Domain.Entities;
using ParkingGarage.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Repository.Repositories
{
    public class FloorRepository : GenericRepository<Floor, long>, IFloorRepository
    {
        public FloorRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
