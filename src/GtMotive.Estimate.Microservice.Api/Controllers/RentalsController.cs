using System;
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
        [HttpPost]
        public async Task<ActionResult<RentalDto>> Create(
            [NotNull] ISender sender,
            [NotNull] IMapper mapper,
            [FromBody][NotNull] CreateRentalDto request)
        {
            var command = new RentAVehicleCommand()
            {
                VehicleId = request.VehicleId,
                CustomerId = request.UserId,
                StartingAt = DateTimeOffset.UtcNow
            };

            var rental = await sender.Send(command, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(Get), new { id = rental.Id }, mapper.Map<RentalDto>(rental));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> Get(
            [NotNull] ISender sender,
            [NotNull] IMapper mapper)
        {
            var query = new GetActiveRentalsRequest();
            var rentals = await sender.Send(query, HttpContext.RequestAborted);
            return Ok(mapper.Map<IEnumerable<RentalDto>>(rentals));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(
            [NotNull] ISender sender,
            [NotNull][FromRoute] Guid id)
        {
            var command = new ReturnAVehicleCommand()
            {
                Id = id
            };

            await sender.Send(command, HttpContext.RequestAborted);
            return NoContent();
        }
    }
}
