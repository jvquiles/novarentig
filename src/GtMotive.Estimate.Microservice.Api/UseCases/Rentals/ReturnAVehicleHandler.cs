using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class ReturnAVehicleHandler(
        IRentalRepository repository)
        : IRequestHandler<ReturnAVehicleCommand>
    {
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
