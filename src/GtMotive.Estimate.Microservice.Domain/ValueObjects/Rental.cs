using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a rental record, including identifiers for the rental, vehicle, and customer.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// </remarks>
    /// <param name="customerId">The unique identifier for the customer.</param>
    /// <param name="vehicleId">The unique identifier for the vehicle.</param>
    /// <param name="startingAt">The start date and time of the rental.</param>
    public class Rental(
        Guid customerId,
        Guid vehicleId,
        DateTimeOffset startingAt)
    {
        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public Guid VehicleId { get; init; } = vehicleId;

        /// <summary>
        /// Gets the unique identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; init; } = customerId;

        /// <summary>
        /// Gets the date and time when the rental ended.
        /// </summary>
        public DateTimeOffset StartingAt { get; init; } = startingAt;

        /// <summary>
        /// Gets the date and time when the operation or event ended.
        /// </summary>
        public DateTimeOffset? EndedAt { get; private set; }

        /// <summary>
        /// Sets the end date and time of the rental, ensuring that it cannot be set to a value before the starting date and time.
        /// </summary>
        /// <param name="endedAt">The end date and time of the rental.</param>
        internal void SentEnding(DateTimeOffset endedAt)
        {
            if (endedAt < StartingAt)
            {
                throw new DomainException("Cannot end a rental before it started");
            }

            EndedAt = endedAt;
        }
    }
}
