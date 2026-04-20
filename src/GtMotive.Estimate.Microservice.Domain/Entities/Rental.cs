using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a rental record, including identifiers for the rental, vehicle, and customer.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// </remarks>
    /// <param name="id">The unique identifier for the rental.</param>
    /// <param name="customerId">The unique identifier for the customer.</param>
    /// <param name="vehicleId">The unique identifier for the vehicle.</param>
    /// <param name="startingAt">The start date and time of the rental.</param>
    /// <param name="endedAt">The end date and time of the rental.</param>
    public class Rental(
        Guid id,
        Guid customerId,
        Guid vehicleId,
        DateTimeOffset startingAt,
        DateTimeOffset? endedAt = null)
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public Guid Id { get; init; } = id;

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
        public DateTimeOffset? EndedAt { get; private set; } = endedAt;

        /// <summary>
        /// Marks the rental as finished by recording the current UTC time as the end time.
        /// </summary>
        /// <remarks>Call this method to indicate that the rental period has ended. The end time is set to
        /// the moment this method is called, using Coordinated Universal Time (UTC).</remarks>
        public void FinishRental()
        {
            EndedAt = DateTimeOffset.UtcNow;
        }
    }
}
