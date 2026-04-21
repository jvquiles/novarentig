using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class RentalsProfile : Profile
    {
        public RentalsProfile()
        {
            CreateMap<Rental, RentalDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId));

            CreateMap<RentalDto, Rental>()
                .ConstructUsing(dto => new Rental(dto.Id, dto.CustomerId, dto.VehicleId, dto.StartingAt, dto.EndedAt));
        }
    }
}
