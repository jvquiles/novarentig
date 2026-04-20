using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    public class AddVehicleHandler(
        IVehicleRepository repository,
        IMapper mapper)
        : IRequestHandler<AddVehicleCommand, VehicleDto>
    {
        public async Task<VehicleDto> Handle(
            [NotNull] AddVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(
                request.VIN,
                request.ManufacturedAt);

            await repository.Add(vehicle, cancellationToken);
            return mapper.Map<VehicleDto>(vehicle);
        }
    }
}
