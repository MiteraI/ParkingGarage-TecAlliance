using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto.Authentication;
using ParkingGarage.Security;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserJwtController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenProvider _tokenProvider;

        public UserJwtController(IAuthenticationService authenticationService, ITokenProvider tokenProvider)
        {
            _authenticationService = authenticationService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet("jwt")]
        [Authorize]
        public string GetJwt()
        {
            var user = User;
            return "jwt";
        }

        [HttpGet("jwt1")]
        [Authorize(Roles = RolesConstants.SECURITY)]
        public string GetJwt1()
        {
            return "jwt1";
        }

        [HttpGet("jwt2")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public string GetJwt2()
        {
            return "jwt2";
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authorize([FromBody] LoginDto loginDto)
        {
            var user = await _authenticationService.Authenticate(loginDto.Username, loginDto.Password);
            var jwt = _tokenProvider.CreateToken(user);
            return Ok(new { jwt });
        }
    }
}
