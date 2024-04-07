using ParkingGarage.Domain.Entities;
using ParkingGarage.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Repository.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle, string>, IVehicleRepository
    {
        public VehicleRepository(IUnitOfWork context) : base(context) 
        {
        }
    }
}
