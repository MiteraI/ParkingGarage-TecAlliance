using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserService(UserManager<User> userManager,
            RoleManager<Role> roleManager, 
            IPasswordHasher<User> passwordHasher, 
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<User> GetUserWithRole()
        {
            var userName = _userManager.GetUserName(_httpContextAccessor.HttpContext.User);
            if (userName == null) return null;
            return await GetUserWithUserRolesByName(userName);
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

        private async Task<User> GetUserWithUserRolesByName(string name)
        {
            return await _userManager.Users
                .Include(it => it.UserRoles)
                .ThenInclude(r => r.Role)
                .SingleOrDefaultAsync(it => it.UserName == name);
        }
    }
}
