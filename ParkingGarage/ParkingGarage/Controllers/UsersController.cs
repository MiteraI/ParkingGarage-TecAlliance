using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("account")]
        public async Task<ActionResult<UserDto>> GetAccount()
        {
            var user = await _userService.GetUserWithRole();
            if (user == null) return BadRequest("User not found");
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet("users")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var dbUsers = await _userService.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(dbUsers);
        }

        [HttpPost("users/create-security")]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            var createdUser = await _userService.CreateSecurityAccount(user, createUserDto.Password);
            return createdUser;
        }
    }
}
