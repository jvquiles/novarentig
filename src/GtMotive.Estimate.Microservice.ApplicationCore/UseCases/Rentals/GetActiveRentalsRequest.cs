using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    /// <summary>
    /// Request to get all active rentals.
    /// </summary>
    public class GetActiveRentalsRequest : IRequest<IEnumerable<Rental>>
    {
    }
}
