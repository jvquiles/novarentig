using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class ReturnAVehicleCommand : IRequest
    {
        public Guid Id { get; init; }
    }
}
