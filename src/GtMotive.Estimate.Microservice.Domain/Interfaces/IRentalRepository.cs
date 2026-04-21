using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

#nullable enable

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Defines a contract for adding rental entities to a data store.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Adds a new rental to the data store.
        /// </summary>
        /// <param name="rental">The rental entity to add. Cannot be null.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous add operation.</returns>
        Task Add(Rental rental, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all active rental records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all rental
        /// records.</returns>
        Task<IEnumerable<Rental>> GetAllActive(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a rental by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the rental.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the rental entity if found; otherwise, null.</returns>
        Task<Rental?> GetById(Guid id);

        /// <summary>
        /// Checks if a customer has any rentals at a specific time.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <param name="specificTime">The specific time to check for active rentals.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the customer has any rentals at the specified time.</returns>
        Task<bool> GetCustomerHasRentalsAtATime(Guid customerId, DateTimeOffset specificTime, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified rental record with new information.
        /// </summary>
        /// <param name="rental">The rental entity containing the updated data. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task Update(Rental rental);
    }
}
