using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
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
        [HttpPost]
        public async Task<ActionResult<RentalDto>> Create(
            [NotNull] ISender sender,
            [FromBody][NotNull] CreateRentalDto request)
        {
            var command = new RentAVehicleCommand()
            {
                VehicleId = request.VehicleId,
                CustomerId = request.UserId
            };

            var rental = await sender.Send(command, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(Get), new { id = rental.Id }, rental);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> Get(
            [NotNull] ISender sender)
        {
            var query = new GetRentalsRequest();
            var rentals = await sender.Send(query, HttpContext.RequestAborted);
            return Ok(rentals);
        }
    }
}
