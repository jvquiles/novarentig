using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class GetActiveRentalsHandler(
        IRentalRepository repository,
        IMapper mapper)
        : IRequestHandler<GetActiveRentalsRequest, IEnumerable<RentalDto>>
    {
        public async Task<IEnumerable<RentalDto>> Handle(
            GetActiveRentalsRequest request,
            CancellationToken cancellationToken)
        {
            var rentals = await repository.GetAllActive(cancellationToken);
            return mapper.Map<IEnumerable<RentalDto>>(rentals);
        }
    }
}
