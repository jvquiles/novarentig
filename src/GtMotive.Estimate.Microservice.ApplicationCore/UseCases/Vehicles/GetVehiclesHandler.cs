using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Handler for the GetVehicles use case, responsible for retrieving a list of vehicles from the repository.
    /// </summary>
    /// <param name="repository">The vehicle repository.</param>
    public class GetVehiclesHandler(
        IVehicleRepository repository)
        : IRequestHandler<GetVehiclesRequest, IEnumerable<Vehicle>>
    {
        /// <summary>
        /// Handles the GetVehiclesRequest by fetching all vehicles from the repository and returning them as an enumerable collection.
        /// </summary>
        /// <param name="request">The request containing the parameters for retrieving vehicles.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation, returning an enumerable collection of vehicles.</returns>
        public async Task<IEnumerable<Vehicle>> Handle(
            GetVehiclesRequest request,
            CancellationToken cancellationToken)
        {
            var vehicles = await repository.GetAll(cancellationToken);
            return vehicles;
        }
    }
}
