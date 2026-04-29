using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for the Vehicle repository, responsible for handling data access related to Vehicle entities.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds the specified vehicle to the data store.
        /// </summary>
        /// <param name="vehicle">The vehicle to add. Cannot be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous add operation.</returns>
        Task Add(Vehicle vehicle, CancellationToken cancellationToken);

        /// <summary>
        /// Checks if the specified customer has rented a vehicle during the specified time period.
        /// </summary>
        /// <param name="customerId">The unique identifier for the customer.</param>
        /// <param name="startingAt">The start date and time of the period to check.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A function that checks if the customer has rented a vehicle during the specified period.</returns>
        Task<bool> CustomerHasRentedAVehicleDuring(Guid customerId, DateTimeOffset startingAt, CancellationToken cancellationToken);

        /// <summary>
        /// Returns all vehicles from the data store.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation returning all vehicles.</returns>
        Task<IEnumerable<Vehicle>> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Returns the vehicle with the specified ID from the data store, or null if no such vehicle exists.
        /// </summary>
        /// <param name="vehicleId">The unique identifier for the vehicle.</param>
        /// <param name="cancellation">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation returning the vehicle or null.</returns>
        Task<Vehicle> GetById(Guid vehicleId, CancellationToken cancellation);

        /// <summary>
        /// Saves the specified vehicle to the data store. If the vehicle already exists, it will be updated; otherwise, it will be added as a new entry.
        /// </summary>
        /// <param name="vehicle">The vehicle to save.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task<Vehicle> Save(Vehicle vehicle, CancellationToken cancellationToken);
    }
}
