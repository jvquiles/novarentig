using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

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

        /// <summary>
        /// Gets the collection of rentals associated with this vehicle. This property represents the rental history of the vehicle.
        /// </summary>
        public IList<Rental> Rentals { get; init; } = [];

        /// <summary>
        /// Starts a new rental for the vehicle with the specified customer ID and starting date. This method creates a new rental instance, adds it to the rentals collection, and returns the newly created rental.
        /// </summary>
        /// <param name="customerId">The ID of the customer renting the vehicle.</param>
        /// <param name="startingAt">The date and time when the rental is starting.</param>
        /// <param name="customerHasRentedAVehicleDuringTask">A function to check if the customer has rented a vehicle during the specified period.</param>
        /// <returns>The newly created rental instance.</returns>
        public async Task<Rental> StartRental(
            Guid customerId,
            DateTimeOffset startingAt,
            [NotNull] Func<Guid, DateTimeOffset, Task<bool>> customerHasRentedAVehicleDuringTask)
        {
            if (ManufacturedAt < startingAt.AddYears(-5))
            {
                throw new DomainException("Can't rent a car with be more than 5 years old.");
            }

            if (Rentals.Any(r => !r.EndedAt.HasValue))
            {
                throw new DomainException("Can't rent a car which is already rented.");
            }

            var customerHasRentedAVehicleDuring = await customerHasRentedAVehicleDuringTask(customerId, startingAt);
            if (customerHasRentedAVehicleDuring)
            {
                throw new DomainException("Can't rent more than one car at a time.");
            }

            var newRental = new Rental(customerId, Id, startingAt);
            Rentals.Add(newRental);
            return newRental;
        }

        /// <summary>
        /// Finishes the specified rental for the vehicle.
        /// </summary>
        /// <returns>The updated rental instance.</returns>
        public Rental FinishRental()
        {
            var currentRental = Rentals.SingleOrDefault(r => !r.EndedAt.HasValue)
                ?? throw new DomainException("This car is not currently rented.");
            currentRental.SentEnding(DateTimeOffset.Now);
            return currentRental;
        }
    }
}
