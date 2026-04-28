using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Command to rent a vehicle. It contains the necessary information to create a new rental, such as the vehicle ID, customer ID and the starting date of the rental.
    /// </summary>
    public class RentAVehicleCommand : IRequest<Rental>
    {
        /// <summary>
        /// Gets the ID of the vehicle to be rented. This is a required field and should be a valid GUID that corresponds to an existing vehicle in the system.
        /// </summary>
        public Guid VehicleId { get; init; }

        /// <summary>
        /// Gets the ID of the customer who is renting the vehicle. This is a required field and should be a valid GUID that corresponds to an existing customer in the system.
        /// </summary>
        public Guid CustomerId { get; init; }

        /// <summary>
        /// Gets the starting date and time of the rental. This is a required field and should be a valid DateTimeOffset value that represents the date and time when the rental period begins.
        /// </summary>
        public DateTimeOffset StartingAt { get; init; }
    }
}
