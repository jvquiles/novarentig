using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class GetRentalsRequest : IRequest<IEnumerable<RentalDto>>
    {
    }
}
