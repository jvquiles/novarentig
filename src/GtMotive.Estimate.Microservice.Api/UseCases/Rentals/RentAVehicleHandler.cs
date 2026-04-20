using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
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
        public async Task<RentalDto> Handle([NotNull] RentAVehicleCommand request, CancellationToken cancellationToken)
        {
            var rental = new Rental
            {
                Id = Guid.CreateVersion7(),
                VehicleId = request.VehicleId,
                CustomerId = request.CustomerId
            };
            await repository.Add(rental, cancellationToken);
            return mapper.Map<RentalDto>(rental);
        }
    }
}
