using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

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
        /// Retrieves all rental records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all rental
        /// records.</returns>
        Task<IEnumerable<Rental>> GetAll(CancellationToken cancellationToken);
    }
}
