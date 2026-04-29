using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Command to return a rented vehicle. It contains the necessary information to identify the rental and process the return.
    /// </summary>
    public class ReturnAVehicleCommand : IRequest
    {
        /// <summary>
        /// Gets the unique identifier of the rental that is being returned. This ID is used to locate the rental record in the system and update its status to reflect the return of the vehicle.
        /// </summary>
        public Guid VehicleId { get; init; }
    }
}
