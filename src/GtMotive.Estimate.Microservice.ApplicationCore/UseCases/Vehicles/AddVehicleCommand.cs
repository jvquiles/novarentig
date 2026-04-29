using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Command to add a new vehicle to the system.
    /// </summary>
    public class AddVehicleCommand : IRequest<Vehicle>
    {
        /// <summary>
        /// Gets the Vehicle Identification Number (VIN) of the vehicle to be added.
        /// </summary>
        public string Vin { get; init; }

        /// <summary>
        /// Gets the make of the vehicle (e.g., Toyota, Ford).
        /// </summary>
        public DateTimeOffset ManufacturedAt { get; init; }
    }
}
