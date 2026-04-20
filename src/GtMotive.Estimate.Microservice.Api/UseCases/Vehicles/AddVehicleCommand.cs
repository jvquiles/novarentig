using System;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class AddVehicleCommand : IRequest<VehicleDto>
    {
        public string VIN { get; init; }

        public DateTimeOffset ManufacturedAt { get; init; }
    }
}
