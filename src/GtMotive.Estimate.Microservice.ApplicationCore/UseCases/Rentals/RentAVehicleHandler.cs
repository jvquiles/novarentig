using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Handles the process of renting a vehicle to a customer. It checks if the customer already has an active rental at the specified time and, if not, creates a new rental record in the repository.
    /// </summary>
    public class RentAVehicleHandler(
        IVehicleRepository repository)
        : IRequestHandler<RentAVehicleCommand, Rental>
    {
        /// <summary>
        /// Handles the RentAVehicleCommand by first checking if the customer already has an active rental at the specified time. If they do, it throws a DomainException. If not, it creates a new Rental object, adds it to the repository, and returns the created rental.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="DomainException">Thrown when the customer already has an active rental at the specified time.</exception>
        /// <param name="request">The command containing the rental details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task<Rental> Handle(
            [NotNull] RentAVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = await repository.GetById(request.VehicleId, cancellationToken);
            var rental = await vehicle.StartRental(
                request.CustomerId,
                request.StartingAt,
                (customerId, startingAt) => repository.CustomerHasRentedAVehicleDuring(customerId, startingAt, cancellationToken));
            await repository.Save(vehicle, cancellationToken);
            return rental;
        }
    }
}
