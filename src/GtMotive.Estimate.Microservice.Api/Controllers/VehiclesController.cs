using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models.Rentals;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<VehicleDto>> CreateVehicle(
            [NotNull] ISender sender,
            [FromBody][NotNull] CreateVehicleDto request)
        {
            var command = new AddVehicleCommand()
            {
                Vin = request.Vin,
                ManufacturedAt = request.ManufacturedAt
            };

            var vehicle = await sender.Send(command, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
        }

        [HttpPost("{vehicleId:guid}/rentals")]
        public async Task<ActionResult<RentalDto>> CreateRental(
            [NotNull] ISender sender,
            [NotNull] IMapper mapper,
            [FromRoute][NotNull] Guid vehicleId,
            [FromBody][NotNull] CreateRentalDto request)
        {
            var command = new RentAVehicleCommand()
            {
                VehicleId = vehicleId,
                CustomerId = request.CustomerId,
                StartingAt = DateTimeOffset.UtcNow
            };

            var rental = await sender.Send(command, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetVehicle), new { id = rental.VehicleId }, mapper.Map<RentalDto>(rental));
        }

        [HttpDelete("{vehicleId:guid}/rentals")]
        public async Task<IActionResult> DeleteRental(
            [NotNull] ISender sender,
            [NotNull][FromRoute] Guid vehicleId)
        {
            var command = new ReturnAVehicleCommand()
            {
                VehicleId = vehicleId
            };

            await sender.Send(command, HttpContext.RequestAborted);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<VehicleDto>> GetVehicle(
            [NotNull] ISender sender)
        {
            var query = new GetVehiclesRequest();
            var vehicles = await sender.Send(query, HttpContext.RequestAborted);
            return Ok(vehicles);
        }
    }
}
