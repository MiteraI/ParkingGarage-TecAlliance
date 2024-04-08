using AutoMapper;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Dto.Floor;

namespace ParkingGarage.Configuration.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Floor, FloorDto>().ReverseMap();
        }
    }
}
