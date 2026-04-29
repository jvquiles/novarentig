using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Handler for the <see cref="AddVehicleCommand"/> command.
    /// </summary>
    /// <param name="repository">The vehicle repository.</param>
    public class AddVehicleHandler(
        IVehicleRepository repository)
        : IRequestHandler<AddVehicleCommand, Vehicle>
    {
        /// <summary>
        /// Handles the <see cref="AddVehicleCommand"/> command by creating a new vehicle and adding it to the repository.
        /// </summary>
        /// <param name="request">The command containing the vehicle details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<Vehicle> Handle(
            [NotNull] AddVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(
                request.Vin,
                request.ManufacturedAt);

            await repository.Add(vehicle, cancellationToken);
            return vehicle;
        }
    }
}
