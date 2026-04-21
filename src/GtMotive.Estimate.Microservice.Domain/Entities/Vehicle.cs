using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle with a unique identifier, vin, and manufacturing date.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="vin">The name of the vehicle.</param>
        /// <param name="manufacturedAt">The date and time when the vehicle was manufactured.</param>
        /// <exception cref="DomainException">Thrown when the manufactured date is more than 5 years old.</exception    >
        public Vehicle(
            string vin,
            DateTimeOffset manufacturedAt)
        {
            if (manufacturedAt < DateTimeOffset.Now.AddYears(-5))
            {
                throw new DomainException("Manufactured date cannot be more than 5 years old.");
            }

            Id = Guid.CreateVersion7();
            Vin = vin;
            ManufacturedAt = manufacturedAt;
        }

        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the vehicle information number associated with this instance.
        /// </summary>
        public string Vin { get; init; }

        /// <summary>
        /// Gets the date and time when the item was manufactured.
        /// </summary>
        public DateTimeOffset ManufacturedAt { get; init; }
    }
}
