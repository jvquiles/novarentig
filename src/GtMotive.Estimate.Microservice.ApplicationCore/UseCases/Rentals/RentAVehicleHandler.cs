using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Handles the process of renting a vehicle to a customer. It checks if the customer already has an active rental at the specified time and, if not, creates a new rental record in the repository.
    /// </summary>
    public class RentAVehicleHandler(
        IRentalRepository repository)
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
            var usersHastRentals = await repository.GetCustomerHasRentalsAtATime(request.CustomerId, request.StartingAt, cancellationToken);
            if (usersHastRentals)
            {
                throw new DomainException("The customer already has an active rental at the specified time.");
            }

            var rental = new Rental(Guid.CreateVersion7(), request.CustomerId, request.VehicleId, request.StartingAt);
            await repository.Add(rental, cancellationToken);
            return rental;
        }
    }
}
