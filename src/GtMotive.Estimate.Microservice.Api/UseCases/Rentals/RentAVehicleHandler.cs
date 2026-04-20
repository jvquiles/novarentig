using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class RentAVehicleHandler(
        IRentalRepository repository,
        IMapper mapper)
        : IRequestHandler<RentAVehicleCommand, RentalDto>
    {
        public async Task<RentalDto> Handle(
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
            return mapper.Map<RentalDto>(rental);
        }
    }
}
