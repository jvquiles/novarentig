using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Handles the return of a rented vehicle. It retrieves the rental information from the repository, marks the rental as finished, and updates the repository with the new state of the rental.
    /// </summary>
    public class ReturnAVehicleHandler(
        IVehicleRepository repository)
        : IRequestHandler<ReturnAVehicleCommand>
    {
        /// <summary>
        /// Handles the return of a rented vehicle. It retrieves the rental information from the repository, marks the rental as finished, and updates the repository with the new state of the rental.
        /// </summary>
        /// <param name="request">The command containing the rental ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown when the rental with the specified ID is not found.</exception>
        public async Task<Unit> Handle(
            [NotNull] ReturnAVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = await repository.GetById(request.VehicleId, cancellationToken)
                ?? throw new ArgumentException($"Vehicle with id {request.VehicleId} not found");
            vehicle.FinishRental();
            await repository.Save(vehicle, cancellationToken);
            return Unit.Value;
        }
    }
}
