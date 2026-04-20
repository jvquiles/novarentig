using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.Vin, opt => opt.MapFrom(src => src.Vin))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ManufacturedAt, opt => opt.MapFrom(src => src.ManufacturedAt));

            CreateMap<VehicleDto, Vehicle>()
                .ConstructUsing(dto => new Vehicle(dto.Vin, dto.ManufacturedAt));
        }
    }
}
