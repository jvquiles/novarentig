using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Handler for the GetActiveRentalsRequest, responsible for retrieving all active rentals from the repository.
    /// </summary>
    /// <param name="repository">The rental repository.</param>
    public class GetActiveRentalsHandler(
        IVehicleRepository repository)
        : IRequestHandler<GetActiveRentalsRequest, IEnumerable<Rental>>
    {
        /// <summary>
        /// Handles the GetActiveRentalsRequest by calling the repository to get all active rentals and returning them as an enumerable collection.
        /// </summary>
        /// <param name="request">The request containing the parameters for retrieving active rentals.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning an enumerable collection of active rentals.</returns>
        public async Task<IEnumerable<Rental>> Handle(
            GetActiveRentalsRequest request,
            CancellationToken cancellationToken)
        {
            var vehicles = await repository.GetAll(cancellationToken);
            return vehicles.SelectMany(x => x.Rentals);
        }
    }
}
