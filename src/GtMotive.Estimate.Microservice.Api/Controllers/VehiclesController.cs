using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Models.Vehicles;
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
        public async Task<ActionResult<VehicleDto>> Create(
            [NotNull] ISender sender,
            [FromBody][NotNull] CreateVehicleDto request)
        {
            var command = new AddVehicleCommand()
            {
                VIN = request.VIN,
                ManufacturedAt = request.ManufacturedAt
            };

            var vehicle = await sender.Send(command);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        [HttpGet]
        public async Task<ActionResult<VehicleDto>> Get(
            [NotNull] ISender sender)
        {
            var query = new GetVehiclesRequest();
            var vehicles = await sender.Send(query);
            return Ok(vehicles);
        }
    }
}
