using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class RentalsProfile : Profile
    {
        public RentalsProfile()
        {
            CreateMap<Rental, RentalDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.EndedAt, opt => opt.MapFrom(src => src.EndedAt));
        }
    }
}
