using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;

        public AuthenticationService(ILogger<AuthenticationService> log, UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public virtual async Task<IPrincipal> Authenticate(string username, string password)
        { 
            var user = await LoadUserByUsername(username);

            if (await _userManager.CheckPasswordAsync(user, password)) return await CreatePrincipal(user);

            throw new InvalidCredentialException("Authentication failed: password does not match stored value");
        }

        private async Task<User> LoadUserByUsername(string username)
        {
            if (new EmailAddressAttribute().IsValid(username))
            {
                var userByEmail = await _userManager.FindByEmailAsync(username);
                if (userByEmail == null) return null;
                    
                return userByEmail;
            }

            var userByLogin = await _userManager.FindByNameAsync(username);
            if (userByLogin == null) return null;

            return userByLogin;
        }

        private async Task<IPrincipal> CreatePrincipal(User user)
        {
            var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var identity = new ClaimsIdentity(claims);
            return new ClaimsPrincipal(identity);
        }
    }
}
