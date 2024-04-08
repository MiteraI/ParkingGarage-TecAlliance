using AutoMapper;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Dto;
using ParkingGarage.Dto.Floor;
using ParkingGarage.Dto.Ticket;

namespace ParkingGarage.Configuration.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Floor, FloorDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}
