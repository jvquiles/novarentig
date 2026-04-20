using System;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class RentAVehicleCommand : IRequest<RentalDto>
    {
        public Guid VehicleId { get; init; }

        public Guid CustomerId { get; set; }

        public DateTimeOffset StartingAt { get; set; }
    }
}
