using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.FunctionalTests.UseCases.Vehicles
{
    public partial class GetVehiclesFunctionalTests
    {
        private sealed class FakeVehicleRepository : IVehicleRepository
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1010:Opening square brackets should be spaced correctly", Justification = "<pendiente>")]
            private readonly List<Vehicle> _store = [];

            public Task Add(Vehicle vehicle, CancellationToken cancellationToken)
            {
                _store.Add(vehicle);
                return Task.CompletedTask;
            }

            public Task<bool> CustomerHasRentedAVehicleDuring(Guid customerId, DateTimeOffset startingAt, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Vehicle>> GetAll(CancellationToken cancellationToken)
            {
                return Task.FromResult(_store.AsEnumerable());
            }

            public Task<Vehicle> GetById(Guid vehicleId, CancellationToken cancellation)
            {
                throw new NotImplementedException();
            }

            public Task<Vehicle> Save(Vehicle vehicle, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
