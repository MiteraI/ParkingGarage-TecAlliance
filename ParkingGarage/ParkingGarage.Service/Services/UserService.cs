using Microsoft.AspNetCore.Identity;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services
{
    public class UserService : IUserService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly RoleManager<Role> _roleManager;
        protected readonly IPasswordHasher<User> _passwordHasher;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateSecurityAccount(User user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            var dbUser = await _userManager.FindByNameAsync(user.UserName);
            if (dbUser != null) throw new InvalidOperationException("User already exists");

            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, RolesConstants.SECURITY);

            return await _userManager.FindByNameAsync(user.UserName);
        }
    }
}
