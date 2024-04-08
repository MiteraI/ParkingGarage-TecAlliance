﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Domain.Entities.Enums;
using ParkingGarage.Dto;
using ParkingGarage.Service.Services.Interfaces;

namespace ParkingGarage.Controllers
{
    [Route("api/admin/[controller]")]
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

        [HttpPost]
        [Authorize(Roles = RolesConstants.ADMIN)]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            var createdUser = await _userService.CreateSecurityAccount(user, createUserDto.Password);
            return createdUser;
        }
    }
}
