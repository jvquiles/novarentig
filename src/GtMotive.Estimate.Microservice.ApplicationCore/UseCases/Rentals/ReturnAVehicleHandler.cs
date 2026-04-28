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
    /// <param name="repository">The rental repository.</param>
    public class ReturnAVehicleHandler(
        IRentalRepository repository)
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
            var rental = await repository.GetById(request.Id)
                ?? throw new ArgumentException($"Rental with id {request.Id} not found");
            rental.FinishRental();
            await repository.Update(rental);
            return Unit.Value;
        }
    }
}
