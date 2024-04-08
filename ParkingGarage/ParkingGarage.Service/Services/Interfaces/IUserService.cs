using ParkingGarage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserWithRole();
        Task<User> CreateSecurityAccount(User user, string password);
    }
}
