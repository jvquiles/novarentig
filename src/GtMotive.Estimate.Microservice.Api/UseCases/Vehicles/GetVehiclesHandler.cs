using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class GetVehiclesHandler(
        IVehicleRepository repository,
        IMapper mapper)
        : IRequestHandler<GetVehiclesRequest, IEnumerable<VehicleDto>>
    {
        public async Task<IEnumerable<VehicleDto>> Handle(
            GetVehiclesRequest request,
            CancellationToken cancellationToken)
        {
            var vehicles = await repository.GetAll(cancellationToken);
            return mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }
    }
}
