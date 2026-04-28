using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    /// <summary>
    /// Request class for the GetVehicles use case, representing a request to retrieve a list of vehicles.
    /// </summary>
    public class GetVehiclesRequest : IRequest<IEnumerable<Vehicle>>
    {
    }
}
