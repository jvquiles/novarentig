using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a rental record, including identifiers for the rental, vehicle, and customer.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public Guid VehicleId { get; init; }

        /// <summary>
        /// Gets the unique identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; init; }
    }
}
