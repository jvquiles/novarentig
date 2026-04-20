using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class GetVehiclesRequest : IRequest<IEnumerable<VehicleDto>>
    {
    }
}
