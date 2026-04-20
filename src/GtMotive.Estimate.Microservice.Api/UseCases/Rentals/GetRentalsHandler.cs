using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals
{
    public class GetRentalsHandler(
        IRentalRepository repository,
        IMapper mapper)
        : IRequestHandler<GetRentalsRequest, IEnumerable<RentalDto>>
    {
        public async Task<IEnumerable<RentalDto>> Handle(GetRentalsRequest request, CancellationToken cancellationToken)
        {
            var rentals = await repository.GetAll(cancellationToken);
            return mapper.Map<IEnumerable<RentalDto>>(rentals);
        }
    }
}
