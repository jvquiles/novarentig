using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> Get(
            [NotNull] ISender sender,
            [NotNull] IMapper mapper)
        {
            var query = new GetActiveRentalsRequest();
            var rentals = await sender.Send(query, HttpContext.RequestAborted);
            return Ok(mapper.Map<IEnumerable<RentalDto>>(rentals));
        }
    }
}
